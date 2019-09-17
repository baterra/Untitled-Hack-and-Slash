using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumpleAttack :   State
{

    public CrumpleAttack()
    {
        atkNum = 0;

    }
    override
    public string getFileName()
    {
        return "CrumpleAttack";
    }

    override
    public string getName()
    {
        return "CrumpleAttack";
    }


    override
    public State getNextState(State requestedState, bool isRecovery)
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

                return this;

            case "Attack":


                return this;

            case "JumpIdle":

                return this;

            case "JumpRun":

                return this;

            case "JumpHitstun":

                return this;


            case "Death":

                return new Death();

            case "Crumple":
                return this;

            default:
                return this;


        }

    }



}