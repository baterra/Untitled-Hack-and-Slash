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
	void Update () {
		
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
            entityInfo.loseStag(stag);
        }  
    }


    public override void ApplyMagicDrain(float mag)
    {
        if (myStateController.GetStateName().Equals("Guard"))
        {
            entityInfo.loseMagic(mag * (entityInfo.Stag / entityInfo.getMaxStag()) );
        }
        entityInfo.loseMagic(mag);
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
            switch (info.type)
            {
                case Damage.DamageType.MagicDrain:
                    entityInfo.loseMagic(value * (entityInfo.Stag / entityInfo.getMaxStag()));
                    break;

                case Damage.DamageType.Stag:
                    entityInfo.loseStag(value * (entityInfo.Stag / entityInfo.getMaxStag()));
                    break;

                default:
                    entityInfo.loseHealth(value * (entityInfo.Stag / entityInfo.getMaxStag()));
                    break;

            }
        }
        else
        {
            // take damage based on new modified value

            switch (info.type)
            {
                case Damage.DamageType.MagicDrain:
                    entityInfo.loseMagic(value );
                    break;

                case Damage.DamageType.Stag:
                    entityInfo.loseStag(value );
                    break;

                default:
                    entityInfo.loseHealth(value );
                    break;

            }
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

    override
    public void AttackTarget(Entity target)
    {
        //target.ApplyDamage(this, new Damage.DamageEventInfo(100f, Damage.DamageType.Water));
        switch (myStateController.GetStateClipName())
        {
            case "test_QSpell_":
                
                target.ApplyDamage( new Damage.DamageEventInfo(500f, Damage.DamageType.Water));
                target.applyKnockBack(6, 0, this);
                target.applyHitstun();
                break;
            case "E":
                break;
            case "R":
                break;
            case "test_Attack1_":
                target.ApplyStagDamage(80f);
                target.ApplyMagicDrain(50f);

                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Holy));
                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Physical));
                
                target.applyKnockBack(3, 0, this);
                target.applyHitstun();
                break;

            case "test_Attack2_":
                target.ApplyStagDamage(80f);
                target.ApplyMagicDrain(50f);

                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Holy));
                target.ApplyDamage( new Damage.DamageEventInfo(100f, Damage.DamageType.Physical));
                target.applyKnockBack(3, 0, this);
                target.applyHitstun();
                break;

            case "test_Parry_":
                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Holy));
                target.ApplyDamage( new Damage.DamageEventInfo(30f, Damage.DamageType.Physical));
                target.applyKnockBack(3, 0, this);
                target.applyHitstun();
                break;
            case "test_RunAttack_":
                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Holy));
                target.ApplyDamage( new Damage.DamageEventInfo(30f, Damage.DamageType.Physical));
                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Fire));
                target.applyKnockBack(3, 0, this);
                target.applyHitstun();
                break;
            case "test_JumpAttack_":
                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Holy));
                target.ApplyDamage( new Damage.DamageEventInfo(50f, Damage.DamageType.Physical));
                target.applyKnockBack(3, 0, this);
                target.applyHitstun();
                break;
            default:
              
                break;

        }
    }



   // public void AttackTarget(Entity target, )
   // {
      
   // }

}
