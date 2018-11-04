using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Entity : MonoBehaviour
{

    public float speed = 10;
    public float jump = 600;

    public EntityInfo entityInfo;
    public StateController myStateController;

    


    public abstract string getEntityName();
    public abstract void AttackTarget(Entity target);

    public virtual void ApplyDamage(object sender, Damage.DamageEventInfo info) { }
    public abstract void applyDamage(float air, float water, float cold, float fire, float thunder, float dark,
       float holy, float ether, float nonelement, float stag, float physical, float magicDrain);

    public abstract void applyKnockBack(float x, float y, bool facing, Entity en);
    public abstract void applyHitstun();



}
