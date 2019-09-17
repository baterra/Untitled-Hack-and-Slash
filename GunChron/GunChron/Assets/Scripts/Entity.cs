using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Entity : MonoBehaviour
{

    public float speed = 10;
    public float jump = 600;

    public EntityInfo entityInfo;
    public StateController myStateController;

    public int breakFrames = 0; // a counter to indicate how long character is in Break state
    public int stagFrames = 0; // a counter to indicate the rate at which the character's stag bar goes down
    public bool isBreak = false;
    public BoxCollider2D groundbx; /// box used to check if entity is touching the ground





    public abstract string getEntityName();


    public abstract void ApplyDamage(Damage.DamageEventInfo info);
    public abstract void ApplyStagDamage(float stag);
    public abstract void ApplyMagicDrain(float mag);

    public abstract void applyKnockBack(float x, float y, Entity en);
    public abstract void applyHitstun();
    public abstract void applyCrumple();

    // public abstract float statModifyDamage(float val);
    //public  void stagModifyDamage(float value, Damage.DamageEventInfo info)
    //{
    //    switch (info.type)
    //    {
    //        case Damage.DamageType.MagicDrain:
    //            entityInfo.loseMagic(value * (entityInfo.Stag / entityInfo.getMaxStag()));
    //            break;

    //        case Damage.DamageType.Stag:
    //            entityInfo.loseStag(value * (entityInfo.Stag / entityInfo.getMaxStag()));
    //            break;

    //        default:
    //            entityInfo.loseHealth(value * (entityInfo.Stag / entityInfo.getMaxStag()));
    //            break;

    //    }
    //}

}
