﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : State {
    public JumpAttack()
    {
        atkNum = 0;
        
    }
    override
    public string getFileName()
    {
        return "JumpAttack";
    }

    override
    public string getName()
    {
        return "JumpAttack";
    }


    override
    public State getNextState(State requestedState, bool isParryable)
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

                return new JumpIdle();

            case "JumpRun":

                return this;

            case "JumpHitstun":

                return new JumpHitstun() ;

            case "Death":

                return new Death();


            default:
                return this;


        }

    }



}