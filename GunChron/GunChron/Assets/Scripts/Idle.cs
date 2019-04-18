using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{


    public Idle()
    {
        atkNum = 0;
        //atkPhase = "";
    }
    override
    public string getFileName()
    {
        return "Idle";
    }

override
public string getName()
    {
        return "Idle";
    }


    override
    public State getNextState(State requestedState, bool isParryable)
    {
        
            switch (requestedState.getName())
            {

                case "Idle":

                    return this;

                case "Run":

                    return new Run();

                case "Guard":

                    return new Guard();

                case "Hitstun":

                    return new Hitstun();

                case "Attack":

                //if ( isParryable) { return new Attack(); } // prevent ground attack on air state
                
                 //return this;

                return new Attack();

            case "JumpIdle":

                    return new JumpIdle();

                case "JumpRun":

                    return this;

                case "JumpHitstun":

                    return this;

            case "QSpell":

                return new QSpell();

            case "ESpell":

                return new ESpell();

            case "RSpell":

                return new RSpell();

            case "Death":

                return new Death();


            default:
                    return this;


            }
       
    }


   
}