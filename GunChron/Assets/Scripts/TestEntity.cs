using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestEntity : Entity {

    public UnityEvent OnTakeDamageUnityEvent;

    public delegate void DamageEvent(object sender, Damage.DamageEventInfo info);
    public event DamageEvent OnTakeDamage;

	// Use this for initialization
	void Start () {

        this.speed = 10;
        this.jump = 600;

        OnTakeDamage += DoThing;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DoThing(object sender, Damage.DamageEventInfo info)
    {
        Debug.Log("Do Thing");
        if (sender.GetType().IsSubclassOf(typeof(MonoBehaviour)))
        {
            Debug.Log("Hit By " + ((MonoBehaviour)sender).gameObject.name);
        }
    }

    override
    public string getEntityName()
    {
        return "test";
    }


    public override void ApplyDamage(object sender, Damage.DamageEventInfo info)
    {
        base.ApplyDamage(sender, info);

        // Invoke Unity Event
        OnTakeDamageUnityEvent.Invoke();

        // Invoke OnTakeDamage event
        OnTakeDamage(sender, info);

        float value = info.damageValue;
        switch (info.type)
        {
            case Damage.DamageType.Physical:
                
                break;
            case Damage.DamageType.Air:
                break;
            case Damage.DamageType.Water:
                value *= 1.5f;
                break;
            case Damage.DamageType.Cold:
                break;
            default:
                break;
        }

        
    }

    public override void applyDamage(float air, float water, float cold, float fire, float thunder, float dark,
       float holy, float ether, float nonelement, float stag, float physical, float magicDrain )
    {
        //(h * Stag / getMaxStag())
        entityInfo.loseStag(stag);

        

        float damageSum = air + (water * (float)1.5) + cold + fire + (thunder * (float)1.5) + (dark / 2) + holy + ether + nonelement + physical;

        if (myStateController.GetStateName().Equals("Guard"))
        {
            entityInfo.loseHealth(damageSum * (entityInfo.Stag / entityInfo.getMaxStag()));
            
        }
        else
        {
            entityInfo.loseHealth(damageSum);
        }
       
        
        entityInfo.loseMagic(magicDrain);
    }

    override
    public void applyKnockBack(float x, float y, bool facing, Entity en)
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
        target.ApplyDamage(this, new Damage.DamageEventInfo(100f, Damage.DamageType.Water));
        switch (myStateController.GetStateClipName())
        {
            case "test_QSpell_":
                target.applyDamage(0, //float air, 
                                   0, //float water, 
                                   0, //float cold,
                                   0,//float fire,
                                   0,//float thunder, 
                                   0,//float dark,
                                   100,//float holy,
                                   0,//float ether,
                                   0,//float nonelement, 
                                   50,//float stag, 
                                   0,//float physical, 
                                   0//float magicDrain
                                   );
                target.ApplyDamage(this, new Damage.DamageEventInfo(100f, Damage.DamageType.Water));
                target.applyKnockBack(6, 0, myStateController.isRight, this);
                //target.applyHitstun();
                break;
            case "E":
                break;
            case "R":
                break;
            case "test_Attack1_":
                target.applyDamage(0, 0, 0, 0, 0, 0,
                50, 0, 0, 50, 100, 0);
                target.applyKnockBack(3, 0, myStateController.isRight, this);
                target.applyHitstun();
                break;

            case "test_Attack2_":
                target.applyDamage(0, 0, 0, 0, 0, 0,
                100, 0, 0, 50, 100, 0);
                target.applyKnockBack(3, 0, myStateController.isRight, this);
                target.applyHitstun();
                break;

            case "test_Parry_":
                target.applyDamage(0, //float air, 
                                   0, //float water, 
                                   0, //float cold,
                                   0,//float fire,
                                   0,//float thunder, 
                                   0,//float dark,
                                   50,//float holy,
                                   0,//float ether,
                                   0,//float nonelement, 
                                   50,//float stag, 
                                   0,//float physical, 
                                   0 //float magicDrain
                                   );
                target.applyKnockBack(3, 0, myStateController.isRight, this);
                target.applyHitstun();
                break;
            case "test_RunAttack_":
                target.applyDamage(0, //float air, 
                                   0, //float water, 
                                   0, //float cold,
                                   20,//float fire,
                                   0,//float thunder, 
                                   0,//float dark,
                                   20,//float holy,
                                   0,//float ether,
                                   0,//float nonelement, 
                                   50,//float stag, 
                                   0,//float physical, 
                                   0 //float magicDrain
                                   );
                target.applyKnockBack(3, 0, myStateController.isRight, this);
                target.applyHitstun();
                break;
            case "test_JumpAttack_":
                target.applyDamage(0, //float air, 
                                   0, //float water, 
                                   0, //float cold,
                                   0,//float fire,
                                   0,//float thunder, 
                                   0,//float dark,
                                   50,//float holy,
                                   0,//float ether,
                                   0,//float nonelement, 
                                   50,//float stag, 
                                   0,//float physical, 
                                   0 //float magicDrain
                                   );
                target.applyKnockBack(3, 0, myStateController.isRight, this);
                target.applyHitstun();
                break;
            default:
              
                break;

        }
    }


}
