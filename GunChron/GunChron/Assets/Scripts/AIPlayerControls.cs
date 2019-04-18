using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerControls : MonoBehaviour {

    public GameObject entityPrefab;
    public StateController TargetState = null;

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

           

        }
        else
        {
            Debug.Log("CHHUNG MUNG MAO!");//
        }




    }

    public void setEntityPrefab(GameObject pb) //////////////////////////POSSIBLY DELETE
    {
        entityPrefab = pb;
    }


    private void calculateNextMove() {
        if (TargetState != null)
        {



        }
    }

    public void checkADKey(float n) // n is the direction the npc will heads towards, a positive number for right and a negative number for left
    {


        

            switch (myStateController.GetStateName())   // this switch sets state to run if its Idle on the ground,
                                                         // or jump run when its idle in the air
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


            if (myStateController.state.getName().Equals("Run")         /// if player is in running state, move the player
                || myStateController.state.getName().Equals("JumpRun"))
            {
                applyRun(n);

            }
            else if (myStateController.state.getName().Equals("Guard")) /// if player is in guarding state, change the direction the player is facing
             {
                applyRunWhenGuard(n);
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
        if (Input.GetKeyUp(KeyCode.A))
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
        if (Input.GetKeyUp(KeyCode.D))
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
            entityPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12);
            // entityPrefab.GetComponent<StateController>().isGround = false;


        }
    }


    public void checkLeftClick()
    {
        

    }

    public void checkLeftClickRelease()
    {
      

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