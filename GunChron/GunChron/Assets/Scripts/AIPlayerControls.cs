using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AIPlayerControls : MonoBehaviour {

    public GameObject entityPrefab; // this entity
    private Entity thisEntity;

    public Entity TargetEntity = null;


    public BoxCollider2D thisHurtAlertBox;
    private LayerMask layers;

    public float fightRadius = 0f;
    public float restRadius = 0f;
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
                if (thisHurtAlertBox.IsTouchingLayers(LayerMask.GetMask("AlerHit"))) //thisAlertBx.incomingAttacks
                {
                    setIdle();
                    setGuard();


                }
                else
                {
                    setIdle();

                    Vector3 dist = thisEntity.GetComponentInParent<Transform>().position - TargetEntity.GetComponentInParent<Transform>().position;

                    if (!isAttacking(dist.x, dist.y))
                    {

                        if (!isCloserX(dist.x))
                        {
                            setRun();
                        }

                        isCloserY(dist.y);

                    }

                    

                    
                    
     
                }


            }

        }


        checkOnGround();

      // myStateController.playCurrState();

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


    private void setRun()
    {
        switch (myStateController.GetStateName())
        {
            case "Idle":
                myStateController.setToRun();
                break;


            case "JumpIdle":
                myStateController.setToJumpRun();
                break;

            default: // Do not try to change states for histun, attack, and crumple states
                     // since those states can transition on their own without the need for this script

                break;


        }
    }

    private bool isAttacking(float xDist, float yDist)
    {
        if (System.Math.Abs(yDist) < fightRadius && System.Math.Abs(xDist) < fightRadius)
        {
            //myStateController.setToAttack();
            myStateController.setToQSpell();
            return true;
        }
        return false;
    }




    private void calculateNextMove() {
       
    }

    private void setJump()
    {
        switch (myStateController.GetStateName())
        {
            case "Idle":
                myStateController.setToJumpIdle();
                break;


            case "Run":
                myStateController.setToJumpRun();
                break;

            default: // Do not try to change states for histun, attack, and crumple states
                     // since those states can transition on their own without the need for this script

                break;


        }
    }

    private bool isCloserY(float yDist)
    {
        if (System.Math.Abs(yDist) > fightRadius && myStateController.GetStateName() != "JumpIdle"
           && myStateController.GetStateName() != "JumpHitstun" && myStateController.GetStateName() != "JumpRun"
           && myStateController.GetStateName() != "JumpAttack" &&
            myStateController.GetStateName() != "Hitstun") // if it is far and entity is on the ground
        {
            setJump();
            entityPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12);
            return false;
            
        }

        return true;
    }

    private bool isCloserX(float xDist)
    {
        if (System.Math.Abs(xDist) > fightRadius ) // if it is far
        {
            setRun();

            Vector3 newPos = thisEntity.GetComponentInParent<Transform>().position;

            if (myStateController.GetStateName() == "Run" || myStateController.GetStateName() == "JumpRun")
            {
                entityPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0,
                   entityPrefab.GetComponent<Rigidbody2D>().velocity.y);              // clear any X momentum that this entity has
                                                                                      // REASON: Entity will toggle between Idle and run state
                                                                                      // while running; 
                                                                                      // This is because the momentum that an entity receives
                                                                                      // from an attack last longer than usual, so by the time 
                                                                                      // entity gets close to its target and stop, the momentum 
                                                                                      // pushes them back causing them to rerun back to the target, 
                                                                                      // creating the toggling between IDLE and RUN state bug.
                                                                                      //CURRENT SOLUTION: clear any momentum when run state but will
                                                                                      // revisit this script to write this code better.

                if (xDist > 0) // if enity is on right of target, have him move left closer to target
                {
                    myStateController.isRight = false;
                    entityPrefab.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
                    newPos += new Vector3(entityPrefab.GetComponent<Entity>().speed * Time.deltaTime * -1, 0, 0);


                }
                else if (xDist < 0)  // if enity is on left of target, have him move right closer to target
                {
                    myStateController.isRight = true;
                    entityPrefab.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                    newPos += new Vector3(entityPrefab.GetComponent<Entity>().speed * Time.deltaTime * 1, 0, 0);

                }

                entityPrefab.GetComponent<Transform>().position = newPos; //update position
            }

           
            
            return false;
        }


        return true;
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



    private void checkOnGround()
    {
        if (thisEntity.groundbx.IsTouchingLayers(LayerMask.GetMask("platform")))
        {
            switch (myStateController.GetStateName())
            {

                case "JumpIdle":
                    myStateController.setToIdle();

                    break;

                case "JumpRun":
                    myStateController.setToRun();

                    break;

                case "JumpHitstun":
                    myStateController.setToCrumple();

                    break;


                default:
                    break;


            }
        }

        else
        {

            switch (myStateController.GetStateName())
            {

                case "Idle":
                    myStateController.setToJumpIdle();
                    break;

                case "Run":
                    myStateController.setToJumpRun();
                    break;

                case "Hitstun":
                    myStateController.setToJumpHitstun();
                    break;


                default:
                    break;


            }
        }
    }


}