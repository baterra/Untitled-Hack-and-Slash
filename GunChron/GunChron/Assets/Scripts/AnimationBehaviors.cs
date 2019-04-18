using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehaviors : MonoBehaviour {

    public StateController myStateController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setToStartup()
    {
        myStateController.atkPhase = "S";
    }


    public void setToActive()
    {
        myStateController.atkPhase = "A";
    }

    public void setToRecovery()
    {
        myStateController.atkPhase = "R"; 
    }

    public void setToIdle() 
    {
        // if air attack -> set to Jump Idle
        myStateController.setToIdle();
    }

    public void setToJumpIdle()
    {
        // if air attack -> set to Jump Idle
        myStateController.setToJumpIdle();
    }



    public void setToNuetral()
    {
        myStateController.atkPhase = "";
    }

    public void eventIsPlaying()
    {
       // Debug.Log("Event Came Through!");//
    }

}
