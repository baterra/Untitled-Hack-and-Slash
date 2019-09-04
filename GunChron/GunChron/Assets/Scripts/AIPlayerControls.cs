using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerControls : MonoBehaviour {

    public GameObject entityPrefab; // this entity
    private Entity thisEntity;

    public Entity TargetEntity = null;


    public BoxCollider2D thisHurtAlertBox;
    private LayerMask layers;

    public float fightDistance = 0f;
    //public 

    private StateController myStateController = null; // this entity's state




    // Use this for initialization
    void Start()
    {
        myStateController = entityPrefab.GetComponent<Entity>().myStateController; // initialize this 
        thisEntity = entityPrefab.GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {

        if (entityPrefab.GetComponent<Entity>() != null)
        {

            if (TargetEntity == null) // if this AI has no target    // !!!!!!!!  EDIT THIS CONDITION TO INCLUDE DEATH STATE !!!!!!!!!!!
            {
                setIdle(); // it does nothing (IDLE STATE)
                //set TargetState = null; if you include death state
            }
            else
            {
                if ( thisHurtAlertBox.IsTouchingLayers(LayerMask.GetMask("AlerHit")) ) //thisAlertBx.incomingAttacks
                {
                    setGuard();


                }
                else
                {
                    setIdle();
                }


            }

        }
      




    }

    public void setEntityPrefab(GameObject pb) //////////////////////////POSSIBLY DELETE
    {
        entityPrefab = pb;
    }

    private void setGuard()
    {
        if (!thisEntity.isBreak) // only block if AI is not in BREAK mode
        {
            myStateController.setToGuard();
        }
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
       
    }



    private bool checkInRange()
    {
        return false;
    }

    //private bool isEnoughMagic() { return false; }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        Entity enemy = collision.GetComponentInParent<Entity>();

        if (TargetEntity == null && enemy != null) // if this AI has no target yet and the collided object is an entity
        {
            TargetEntity = enemy; // set target
        }



     }



}