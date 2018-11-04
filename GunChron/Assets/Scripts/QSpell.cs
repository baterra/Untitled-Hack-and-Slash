using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QSpell : State
{
    public QSpell()
    {
        atkNum = 0;

    }
    override
    public string getFileName()
    {
        return "QSpell";
    }

    override
    public string getName()
    {
        return "QSpell";
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

                return this;

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