using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
   
    
    public GameObject entityPrefab;


    private StateController myStateController =null;
    public bool mouseIsDown = false;



    // Use this for initialization
    void Start () {
        myStateController = entityPrefab.GetComponent<Entity>().myStateController;
    }
	
	// Update is called once per frame
	void Update () {

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
            //checkRightClickRelease(); // spellcasting

        }
        //else {
         //   Debug.Log("CHHUNG MUNG MAO!");//
       // }
        



    }



    public void checkADKey(float n)
    {
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

            switch (myStateController.GetStateName())
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
           

            if (myStateController.state.getName().Equals("Run") 
                || myStateController.state.getName().Equals("JumpRun"))
            {
                applyRun( n);

            }
            else if (myStateController.state.getName().Equals("Guard")) {
                applyRunWhenGuard( n);
            }

        }

       
    }



    private void applyRun(float n)
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

        Vector3 newPos = entityPrefab.GetComponent<Transform>().position;
        newPos += new Vector3(entityPrefab.GetComponent<Entity>().speed * Time.deltaTime
            * n, 0, 0);///
        entityPrefab.GetComponent<Transform>().position = newPos;
    }





    private void applyRunWhenGuard(float n)
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
        if (Input.GetKey(KeyCode.S))
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
        if (Input.GetKey(KeyCode.W) 
           
            && (myStateController.state.getName().Equals("Run") ||
                myStateController.state.getName().Equals("Idle") 
                || myStateController.state.getName().Equals("Hitstun")) 
                )
        {
            myStateController.atkPhase = "S";
          entityPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0,12); 
           // entityPrefab.GetComponent<StateController>().isGround = false;


        }
    }


    public void checkLeftClick()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !mouseIsDown)
        {
            myStateController.setToAttack();
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


    /// <summary>
    /// DONT FORGET TO PUT THESE FUNCTIONS INTO UPDATE() FUNCTION
    /// </summary>
    /// 


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
