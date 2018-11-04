using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : State
{
    public Parry()
    {
        atkNum = 0;

    }
    override
    public string getFileName()
    {
        return "Parry";
    }

    override
    public string getName()
    {
        return "Parry";
    }


    override
    public State getNextState(State requestedState, bool isParryable)
    {

        switch (requestedState.getName())
        {

            case "Idle":

                return new Idle();

            case "Run":

                return this;

            case "Guard":

                return this;

            case "Hitstun":

                return new Hitstun();

            case "Attack":


                return this;

            case "JumpIdle":

                return this;

            case "JumpRun":

                return this;

            case "JumpHitstun":

                return this;


            default:
                return this;


        }

    }



}