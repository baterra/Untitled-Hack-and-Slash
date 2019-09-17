using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : State {


    public Death()
    {
        atkNum = 0;
        //atkPhase = "";
    }
    override
    public string getFileName()
    {
        return "Death";
    }

    override
    public string getName()
    {
        return "Death";
    }


    override
    public State getNextState(State requestedState, bool isRecovery)
    {

        switch (requestedState.getName())
        {

            case "Idle":

                return this;

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


            default:
                return this;


        }

    }


}
