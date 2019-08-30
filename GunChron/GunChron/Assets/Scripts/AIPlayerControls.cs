using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerControls : MonoBehaviour {

    public GameObject entityPrefab;
    public StateController TargetState = null;
    public float fightDistance = 0f;
    //public 

    private StateController myStateController = null;




    // Use this for initialization
    void Start()
    {
        myStateController = entityPrefab.GetComponent<Entity>().myStateController;
    }

    // Update is called once per frame
    void Update()
    {

        if (entityPrefab.GetComponent<Entity>() != null)
        {

            if (TargetState == null) // if this AI has no target    // !!!!!!!!  EDIT THIS CONDITION TO INCLUDE DEATH STATE !!!!!!!!!!!
            {
                setIdle(); // it does nothing (IDLE STATE)
            }
            else
            {



            }

        }
      




    }

    public void setEntityPrefab(GameObject pb) //////////////////////////POSSIBLY DELETE
    {
        entityPrefab = pb;
    }

    private void setIdle()
    {
        switch (myStateController.GetStateName())
        {
            case "Idle":
                myStateController.setToIdle();
                break;

            case "Run":
                myStateController.setToIdle();
                break;

            case "JumpRun":
                myStateController.setToJumpIdle();
                break;

            case "JumpIdle":
                myStateController.setToJumpIdle();
                break;

            case "Guard":
                myStateController.setToIdle();
                break;



            default: // Do not try to change states for histun, attack, and crumple states
                        // since those states can transition on their own without the need for this script
      
                break;


        }
    }

 


    private void calculateNextMove() {
        if (TargetState != null)
        {


        }
    }


    private bool isFacingAI()
    {
        bool isFace = TargetState.isRight; // direction enemy is facing
        //bool isLeftOf = TargetState.GetComponentsInParent<Transform>().; // if AI is left of right of enemy

        return false;
    }

    private bool checkInRange()
    {
        return false;
    }

    //private bool isEnoughMagic() { return false; }




}