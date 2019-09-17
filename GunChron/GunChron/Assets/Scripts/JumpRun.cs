using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRun : State
{


    public JumpRun()
    {
        atkNum = 0;
        //atkPhase = "";
    }

    override
    public string getFileName()
    {
        return "JumpRun";
    }

    override
    public string getName()
    {
        return "JumpRun";
    }



    override
     public State getNextState(State requestedState, bool isRecovery)
    {

        switch (requestedState.getName())
        {

            case "Idle":

                return this;

            case "Run":

                return new Run();

            case "Guard":

                return this;

            case "Hitstun":

                return this;

            case "Attack":

                return new JumpAttack();

            case "JumpIdle":

                return new JumpIdle();

            case "JumpRun":

                return this;

            case "JumpHitstun":

                return new JumpHitstun();

            case "Death":

                return new Death();

            case "Crumple":
                return new JumpHitstun();


            default:
                return this;


        }

    }



}