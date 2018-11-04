using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcasting : State
{


    public Spellcasting()
    {
        atkNum = 0;
        //atkPhase = "";
    }

    override
    public string getFileName()
    {
        return "Spellcasting";
    }

    override
    public string getName()
    {
        return "Spellcasting";
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

                return new Hitstun();

            case "Attack":

                return this;

            case "JumpIdle":

                return this;

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


            default:
                return this;


        }

    }



}