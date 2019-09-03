using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
    public Entity thisEntity; // entity that the hitbox is attached to

    public float xKnock = 0; // knock back distance
    public float yKnock = 0;

    public float magDrain = 0; // diffrenent damages
    public float stgDmg = 0;
    //public float dmg = 0;

    public bool isHitstun = false; 

    //public int dmgType = 0; // enum int value associated with the type of elemental damage values

    public int[] damages= new int[9]; // indexes are the element type and the array values are the associated dmg value






    private void takeDamage(Entity enemy)
    {

        for (int i = 0; i< damages.Length; i++)
        {
            enemy.ApplyDamage(new Damage.DamageEventInfo(damages[i], (Damage.DamageType)i));
        }

    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        Entity enemy = collision.GetComponentInParent<Entity>();

        

        if (enemy != null)
        {
            // enemy.myStateController.GetStateName() == "Guard" foer MAGIC states

           // if (enemy.myStateController.GetStateName() != "Guard")
            //{
                enemy.ApplyStagDamage(stgDmg); // increase stagger bar of enemy

                enemy.ApplyMagicDrain(magDrain); // reduce enemy's magic bar

                takeDamage( enemy);


                enemy.applyKnockBack(xKnock, yKnock, thisEntity); // apply knockback to enemy

                if (isHitstun) { enemy.applyHitstun(); } // apply hitstun to enemy

                // apply Crumple function

            //}

        }

    }


}
