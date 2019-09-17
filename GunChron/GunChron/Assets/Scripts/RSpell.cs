using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSpell : State
{
    public RSpell()
    {
        atkNum = 0;

    }
    override
    public string getFileName()
    {
        return "RSpell";
    }

    override
    public string getName()
    {
        return "RSpell";
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


            default:
                return this;


        }

    }



}