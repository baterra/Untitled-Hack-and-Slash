using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : State {


    public Guard()
    {
        atkNum = 0;
        //atkPhase = "";
    }

    override
    public string getFileName()
    {
        return "Guard";
    }

    override
    public string getName()
    {
        return "Guard";
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

                return new Parry();

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