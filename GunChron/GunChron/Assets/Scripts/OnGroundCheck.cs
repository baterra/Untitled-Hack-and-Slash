using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundCheck : MonoBehaviour {
    public bool onGround = true;
    public BoxCollider2D groundbx;
    
    public StateController myStateController;

	
	// Update is called once per frame
	void Update () {

        string name = myStateController.GetStateName();

        if (!groundbx.IsTouchingLayers(LayerMask.GetMask("platform")))
        {
            switch (name)
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

        else
        {
            switch (name)
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
        }
		
	}

  
    //private void OnTriggerStay2D(Collider2D collision)
   // {
        
    //    onGround = true;
    //}

   // private void OnTriggerExit2D(Collider2D collision)
   // {
    //    onGround = false;
    //}

  

   
}
