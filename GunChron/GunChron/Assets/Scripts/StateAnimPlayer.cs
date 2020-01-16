using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAnimPlayer : MonoBehaviour
{
    public Animator stateAnimator;
    public PlayMakerFSM entityStateMachine;
    public GameObject entityPrefab;

    public void Update()
    {
        playCurrState();
    }



    public void playCurrState()
    { 

        if (!stateAnimator.GetCurrentAnimatorStateInfo(0).IsName(entityStateMachine.ActiveStateName)
           ) 
           // && !entityStateMachine.FsmVariables.GetFsmBool("isRecovery").Value

        // check whether the state going to be played
        // is already playing
        {
            stateAnimator.Play(entityStateMachine.ActiveStateName); // play this state

            

        }
        //checkJump();
        checkRun(Input.GetAxis("Horizontal")); // check if player is running
    }


    public void checkRun(float n)
    {
        

        if (entityStateMachine.ActiveStateName == "RunRight" || entityStateMachine.ActiveStateName == "RunLeft"
            || entityStateMachine.ActiveStateName == "Jump" )
        {
            if (n < 0) // character faces to the left if running to the left
            {
                
                entityPrefab.GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (n > 0) // character faces to the right if running to the right
            {
                
                entityPrefab.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            }

            Vector3 newPos = entityPrefab.GetComponent<Transform>().position; // move the character one step up
            newPos += new Vector3(entityPrefab.GetComponent<Entity>().speed * Time.deltaTime
                * n, 0, 0);///
            entityPrefab.GetComponent<Transform>().position = newPos;

        }
 

    }

    public void checkJump()
    {
        if (Input.GetKey(KeyCode.W) && (entityStateMachine.ActiveStateName == "Idle" || 
            entityStateMachine.ActiveStateName == "RunLeft" || entityStateMachine.ActiveStateName == "RunRight")
            )
        {
             
            entityPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12);
        }
    }



}
