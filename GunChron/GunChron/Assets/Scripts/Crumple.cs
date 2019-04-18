using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumple : State
{

    public Crumple()
    {
        atkNum = 0;
        //atkPhase = "";
    }
    override
    public string getFileName()
    {
        return "Crumple";
    }

    override
    public string getName()
    {
        return "Crumple";
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

            case "QSpell":

                return this;

            case "ESpell":

                return this;

            case "RSpell":

                return this;

            case "Death":

                return new Death();


            default:
                return this;


        }

    }



}
