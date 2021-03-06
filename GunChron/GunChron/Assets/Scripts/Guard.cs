﻿using System.Collections;
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
    public State getNextState(State requestedState, bool isRecovery)
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

            case "Death":

                return new Death();


            default:
                return this;


        }

    }



}