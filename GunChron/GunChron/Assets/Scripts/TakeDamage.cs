using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
    public Entity thisEntity; // entity that the hitbox is attached to
    public float xKnock = 0;
    public float yKnock = 0;
    public float magDrain = 0;
    public float stgDmg = 0;
    public float dmg = 0;
    public bool isHitstun = false;
    public int dmgType = 0;

   







    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.attachedRigidbody.GetComponent<Entity>() != null) {
            Entity enemy = collision.attachedRigidbody.GetComponent<Entity>();
            
            enemy.ApplyStagDamage(stgDmg);
            enemy.ApplyMagicDrain(magDrain);

            enemy.ApplyDamage(new Damage.DamageEventInfo(dmg, (Damage.DamageType)dmgType  )); // (Damage.DamageType)dmgType casts the int number into enum value

           

            enemy.applyKnockBack(xKnock, yKnock, thisEntity);
            
            if (isHitstun) {  enemy.applyHitstun();  }

            // apply Crumple function

            }



    }


}
