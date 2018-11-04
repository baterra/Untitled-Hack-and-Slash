using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public State state = new Idle(); //

    public string stateNameShow;/// /////
    public int currAtkNum;///

    public string entireFileName;///
    public string entireFileNameHit;///

  

    public bool isParryable = false;
    public bool isRight = true;
    public string atkPhase = "";

    public int maxCombo = 2;

    public Animator stateAnimator;


    //public Entity entity;

    


    public string entityName;///


    void Start () {
        stateNameShow = state.getFileName();//
        currAtkNum = state.atkNum;//
        
        
    }
	
	// Update is called once per frame
	void Update () {

        if (atkPhase.Equals("I"))
        {
            setToIdle();
            playCurrState();
            atkPhase = "";
        }
        else { playCurrState(); }
       

        stateNameShow = state.getFileName();//
        currAtkNum = state.atkNum;////////////////
      
        
    }

    public void playCurrState()
    { ///myAnimator.Play("Idle");
        


        if (!stateAnimator.GetCurrentAnimatorStateInfo(0).IsName(GetStateClipName()))
                                                                                                    // check whether the state going to be played
                                                                                                   // is already playing
        {
            stateAnimator.Play(GetStateClipName()); // play this state
           
            if (!stateAnimator.GetCurrentAnimatorStateInfo(0).IsName(GetStateClipName())) {
                entireFileName = GetStateClipName();

            }
        }
    }

    public string GetStateClipName()
    {
        return (entityName + "_" + state.getFileName() + "_");
    }

    public string GetHitboxClipName()
    {
        return (entityName + "_" + state.getFileName()  + "_Hitbox_");
    }

    public void SetBattleState(State requestedState)
    {
        state = state.getNextState(requestedState, isParryable);
    }

    public void ChangeState(State nextState)
    {
        if(state != null)
        {
            state.OnExit();
        }
        state = nextState;
        state.controller = this;
        state.OnEnter();
    }

    public void setToIdle()
    {
        ChangeState(state.getNextState(new Idle(), isParryable));

        //state = state.getNextState(new Idle(), isParryable);
    }

    public void setToAttack()
    {
        if (state.atkNum < maxCombo) {
            state = state.getNextState(new Attack(), isParryable);
        }
        
    }

    public void setToGuard()
    {
        state = state.getNextState(new Guard(), isParryable);
    }

    public void setToRun()
    {
        state = state.getNextState(new Run(), isParryable);
    }

    public void setToHitstun()
    {
        state = state.getNextState(new Hitstun(), isParryable);
        if (state.getName().Equals("Hitstun")) {
            stateAnimator.Play(GetStateClipName(), 0, 0); // play this state
           
        }
            
    }

    public void setToJumpHitstun()
    {
       
        state = state.getNextState(new JumpHitstun(), isParryable);
      
     }

    public void setToJumpIdle()
    {
        state = state.getNextState(new JumpIdle(), isParryable);
    }

    public void setToJumpRun()
    {
        state = state.getNextState(new JumpRun(), isParryable);
    }

    public void setToSpellcasting()
    {

        state = state.getNextState(new Spellcasting(), isParryable);

    }

    public void setToQSpell()
    {

        state = state.getNextState(new QSpell(), isParryable);

    }

    public void setToESpell()
    {

        state = state.getNextState(new ESpell(), isParryable);

    }

    public void setToRSpell()
    {

        state = state.getNextState(new RSpell(), isParryable);

    }

    public void setIsParryable(bool state)
    {
        isParryable = state;
    }

    public void SetFacingState(bool state)
    {
        isRight = state;
    }

    public string GetStateName()
    {
        return state.getName();
    }





    public int getFacingint()
    {
        if (isRight) { return 1; }
        return -1;
    }





}
