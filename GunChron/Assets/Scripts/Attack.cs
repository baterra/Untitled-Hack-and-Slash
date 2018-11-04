using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    public Attack(int num)
    {
        atkNum = num;
        //atkPhase = "";
    }

    public Attack()
    {
        atkNum = 1;
       // atkPhase = "";
    }

    override
    public string getFileName()
    {
        return "Attack" + atkNum;
    }

    override
    public string getName()
    {
        return "Attack" ;
    }


    //if (atkPhase.Equals("R")) { return new Attack(atkNum + 1);}
    // return this;


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

                //return new Attack();//////////
                if ( isParryable) { return new Attack(atkNum + 1); }
             return this;

            case "JumpIdle":

                return  this;

            case "JumpRun":

                return  this;

            case "JumpHitstun":

                return  this;


            default:
                return  this;


        }

    }



}
