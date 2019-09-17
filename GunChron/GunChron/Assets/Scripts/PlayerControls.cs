using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
   
    
    public GameObject entityPrefab;


    private StateController myStateController =null;
    public bool mouseIsDown = false;
    private Entity thisEntity;



    // Use this for initialization
    void Start () {
        myStateController = entityPrefab.GetComponent<Entity>().myStateController;
        thisEntity = entityPrefab.GetComponent<Entity>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (entityPrefab.GetComponent<Entity>() != null)
        {
           
            checkADKey(Input.GetAxis("Horizontal")); // check if player is running

            checkKeyS(); // check if player is guarding 
            checkKeyW(); // check if player is jumping
            checkLeftClick();
            //checkRightClick(); // spellcasting
            checkQKey();
            checkRKey();
            checkEKey();

            checkKeyDRelease(); // check if the keys are released
            checkKeyARelease();
            checkKeySRelease();/////
            checkLeftClickRelease();

            checkOnGround();

            //myStateController.playCurrState();

        }
        //else {
         //   Debug.Log("CHHUNG MUNG MAO!");//
       // }
        



    }



    public void checkADKey(float n)
    {
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

            switch (myStateController.GetStateName()) // change to run state depending on whether player is on ground or air
            {

                case "Idle":
                    myStateController.setToRun();
                    break;

                case "JumpIdle":
                    myStateController.setToJumpRun();
                    break;

                default:
                    break;


            }
            //entityPrefab.GetComponent<StateController>().setToRun();
           

            if (myStateController.state.getName().Equals("Run") // if  player successfully changes to run state, move the character
                || myStateController.state.getName().Equals("JumpRun"))
            {
                applyRun( n);

            }
            else if (myStateController.state.getName().Equals("Guard")) { // if player is actually blocking, change their facing direction
                changeGuardDirection( n);
            }

        }

       
    }



    private void applyRun(float n)
    {

        if (n < 0) // character faces to the left if running to the left
        {
            myStateController.isRight = false;
            entityPrefab.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (n > 0) // character faces to the right if running to the right
        {
            myStateController.isRight = true;
            entityPrefab.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }

        Vector3 newPos = entityPrefab.GetComponent<Transform>().position; // move the character one step up
        newPos += new Vector3(entityPrefab.GetComponent<Entity>().speed * Time.deltaTime
            * n, 0, 0);///
        entityPrefab.GetComponent<Transform>().position = newPos;
    }





    private void changeGuardDirection(float n)
    {

        if (n < 0)
        {
            myStateController.isRight = false;
            entityPrefab.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (n > 0)
        {
            myStateController.isRight = true;
            entityPrefab.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }
    }







    public void checkKeyARelease()
    {
        if (Input.GetKeyUp(KeyCode.A) )
        {
            switch (myStateController.GetStateName())
            {
                case "Run":
                    myStateController.setToIdle();
                    break;

                case "JumpRun":
                    myStateController.setToJumpIdle();
                    break;

                default:
                    break;

            }
          
        }
    }



    public void checkKeyDRelease() 
    {
        if (Input.GetKeyUp(KeyCode.D)  )
        {
            switch (myStateController.GetStateName())
            {



                case "Run":
                    myStateController.setToIdle();
                    break;

                case "JumpRun":
                    myStateController.setToJumpIdle();
                    break;


                default:
                    break;


            }
        }
    }



    public void checkKeyS()
    {
        if (Input.GetKey(KeyCode.S) && !thisEntity.isBreak)
        {
            myStateController.setToGuard();
            
        }
    }

    public void checkKeySRelease()
    {
        if (Input.GetKeyUp(KeyCode.S) && myStateController.state.getName().Equals("Guard"))
        {
            myStateController.setToIdle();
        }

        //entityPrefab.GetComponent<Transform>().
    }


    public void checkKeyW()
    {
        // !groundbx.IsTouchingLayers(LayerMask.GetMask("platform"))
        //!thisEntity.groundbx.IsTouchingLayers(LayerMask.GetMask("platform"))

        if (Input.GetKey(KeyCode.W) && thisEntity.groundbx.IsTouchingLayers(LayerMask.GetMask("platform"))
                && (myStateController.state.getName().Equals("Run") ||
                myStateController.state.getName().Equals("Idle") ) )
        {
            if (myStateController.state.getName().Equals("Run"))
            {
                myStateController.setToJumpRun();
          
                entityPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12);
            }
            else if (myStateController.state.getName().Equals("Idle"))
            {
                myStateController.setToJumpIdle();
                Debug.Log("Set to Jump State");
                entityPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12);
            }

            
           // entityPrefab.GetComponent<StateController>().isGround = false;


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
        
        else {
            
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


    public void checkLeftClick()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !mouseIsDown)
        {
            myStateController.setToAttack();
            Debug.Log("Set to attack state");
            mouseIsDown = true;

        }
       
    }

    public void checkLeftClickRelease()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) )
        {
            mouseIsDown = false;
        }

        //entityPrefab.GetComponent<Transform>().
    }


 
    /// DONT FORGET TO PUT THESE FUNCTIONS INTO UPDATE() FUNCTION



    public void checkRightClick()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            myStateController.setToSpellcasting();


        }
    }

    public void checkRightClickRelease()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1) && myStateController.state.getName().Equals("Spellcasting"))
        {
            myStateController.setToIdle();
        }

        //entityPrefab.GetComponent<Transform>().
    }



    public void checkQKey()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            myStateController.setToQSpell();


        }
    }


    public void checkEKey()
    {
        if (Input.GetKey(KeyCode.E))
        {
            myStateController.setToESpell();


        }
    }

    public void checkRKey()
    {
        if (Input.GetKey(KeyCode.R))
        {
            myStateController.setToRSpell();


        }
    }
    //right click : change spells





}
