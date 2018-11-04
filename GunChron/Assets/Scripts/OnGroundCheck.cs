using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundCheck : MonoBehaviour {
    public bool onGround = true;
    
    public StateController myStateController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!onGround)
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

  
    private void OnTriggerStay2D(Collider2D collision)
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
                myStateController.setToHitstun();

                break;


            default:
                break;


        }
        onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }

  

   
}
