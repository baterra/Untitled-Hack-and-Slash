using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestEntity : Entity {

    //public UnityEvent OnTakeDamageUnityEvent;

    //public delegate void DamageEvent(object sender, Damage.DamageEventInfo info);
   // public event DamageEvent OnTakeDamage;

	// Use this for initialization
	void Start () {

        this.speed = 10;
        this.jump = 600;

      //  OnTakeDamage += DoThing;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (entityInfo.Stag > 0 && entityInfo.Stag < entityInfo.getMaxStag())
        {
            if (myStateController.GetStateName() == "Guard")
            {
                stagFrames = 0;
            }
            else
            {
                stagFrames++;
                if (stagFrames >= 120)
                {
                    stagFrames = 0;
                    entityInfo.loseStag(entityInfo.getMaxStag() * .03333f);
                    
                }
                    
            }
                
        }

        if (entityInfo.Stag >= entityInfo.getMaxStag())
        {
            isBreak = true;
            breakFrames++;
            if (breakFrames >= 900 )
            {
                entityInfo.Stag = 0;
                breakFrames = 0;
                stagFrames = 0;
                isBreak = false;
            }
            
        

        }

    }



    override
    public string getEntityName()
    {
        return "test";
    }


    public override void ApplyStagDamage(float stag)
    {
        if (myStateController.GetStateName().Equals("Guard")) 
        {
            entityInfo.gainStag(stag);
        }  
    }


    public override void ApplyMagicDrain(float mag)
    {
        if (myStateController.GetStateName().Equals("Guard"))
        {
            entityInfo.loseMagic(mag * (entityInfo.Stag / entityInfo.getMaxStag()));
        }
        else { entityInfo.loseMagic(mag); }
        
    }


    public override void ApplyDamage( Damage.DamageEventInfo info)
    {
        float value = info.damageValue;

        switch (info.type)   // Apply modifiers to damage value: Reduced/ boost
        {
            case Damage.DamageType.Thunder:
                value *= 1.5f; // increased damage 1/2 more damage // weakness damage
                break;
            case Damage.DamageType.Holy:
                value *= 0.5f; // reduced damage // resistance damage
                break;
            case Damage.DamageType.Water:
                value *= 1.5f; // increased damage 1/2 more damage
                break;
            case Damage.DamageType.Cold:
                break;
            default:
                break;
        }

        


        if (myStateController.GetStateName().Equals("Guard")) // take partial damage based on stag bar/ still accounts for 
                                                                //elemental weaknesses
        {
            
                    entityInfo.loseHealth(value * (entityInfo.Stag / entityInfo.getMaxStag()));
                    

            
        }
        else
        {
            // take damage based on new modified value

                    entityInfo.loseHealth(value );
                   
        }

    }

   

    override
    public void applyKnockBack(float x, float y, Entity en)
    {
        
        if ((en.transform.position.x - this.transform.position.x) <= 0)
        {
            entityInfo.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y); // FIX to ALLOW 
                                                                                 // adding onto current velocity
        }
        else {
            entityInfo.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * x, y); // FIX to ALLOW 
                                                                                      // adding onto current velocity
                 
        }



    }

    override
    public void applyHitstun()
    {
        if (myStateController.state.getName().Equals("JumpIdle") ||
            myStateController.state.getName().Equals("JumpHitstun") ||
            myStateController.state.getName().Equals("JumpAttack"))
            myStateController.setToJumpHitstun();

        else
            myStateController.setToHitstun();


    }




  

}
