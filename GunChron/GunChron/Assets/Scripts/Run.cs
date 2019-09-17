using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State {


    public Run()
    {
        atkNum = 0;
       
    }

    override
    public string getFileName()
    {
        return "Run";
    }

    override
    public string getName()
    {
        return "Run";
    }



    override
    public State getNextState(State requestedState,  bool isRecovery)
    {

        switch (requestedState.getName())
        {

            case "Idle":

                return new Idle();

            case "Run":

                return this;

            case "Guard":

                return new Guard();

            case "Hitstun":

                return new Hitstun();

            case "Attack":

                return new RunAttack();

            case "JumpIdle":

                return this;

            case "JumpRun":

                return new JumpRun();

            case "JumpHitstun":

                return this;

            case "Death":

                return new Death();

            case "Crumple":
                return new Crumple();


            default:
                return this;


        }

    }



}