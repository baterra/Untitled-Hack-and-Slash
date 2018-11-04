using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State // : ScriptableObject
{

    public int atkNum;
    public StateController controller;


    //public abstract void apply(Entity e, double dt);

    //public abstract State getNextState(BattleState b, Entity e);

    public abstract string getName();
    public abstract string getFileName();

    public abstract State getNextState(State requestedState, bool isParryable);

    public void setAtkPhase(string phase)
    {
        //atkPhase = phase;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }

}
