using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHitstun : State
{


    public JumpHitstun()
    {
        atkNum = 0;
        //atkPhase = "";
    }

    override
    public string getFileName()
    {
        return "JumpHitstun";
    }

    override
    public string getName()
    {
        return "JumpHitstun";
    }


    override
     public State getNextState(State requestedState, bool isParryable)
    {

        switch (requestedState.getName())
        {

            case "Idle":

                return new JumpHitstun();

            case "Run":

                return new JumpHitstun();

            case "Guard":

                return new JumpHitstun();

            case "Hitstun":

                return new Hitstun();

            case "Attack":

                return new JumpHitstun();

            case "JumpIdle":

                return new JumpIdle();

            case "JumpRun":

                return new JumpHitstun();

            case "JumpHitstun":

                return new JumpHitstun();

            case "Death":

                return new Death();


            default:
                return new JumpHitstun();


        }

    }



}