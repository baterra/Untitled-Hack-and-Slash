using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitstun : State {

    public Hitstun()
    {
        atkNum = 0;
        //atkPhase = "";
    }

    override
    public string getFileName()
    {
        return "Hitstun";
    }

    override
    public string getName()
    {
        return "Hitstun";
    }


    override
       public State getNextState(State requestedState, bool isParryable)
    {

        switch (requestedState.getName())
        {

            case "Idle":

                return new Idle();

            case "Run":

                return new Hitstun();

            case "Guard":

                return new Hitstun();

            case "Hitstun":

                return new Hitstun();

            case "Attack":

                return new Hitstun();

            case "JumpIdle":

                return new Hitstun();

            case "JumpRun":

                return new Hitstun();

            case "JumpHitstun":

                return new JumpHitstun();


            default:
                return new JumpHitstun();


        }

    }



}