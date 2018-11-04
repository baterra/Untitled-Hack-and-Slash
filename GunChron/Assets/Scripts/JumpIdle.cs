using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIdle : State
{
    

    public JumpIdle()
    {
        atkNum = 0;
        //atkPhase = "";
    }

    override
    public string getFileName()
    {
        return "JumpIdle";
    }

    override
    public string getName()
    {
        return "JumpIdle";
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

                return new JumpAttack();

            case "JumpIdle":

                return this;

            case "JumpRun":

                return new JumpRun();

            case "JumpHitstun":

                return new JumpHitstun();


            default:
                return this;


        }

    }



}