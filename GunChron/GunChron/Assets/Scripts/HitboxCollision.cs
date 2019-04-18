using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCollision : MonoBehaviour {
    public Entity thisEntity; // entity that the hitbox is attached to
 


 



    private void OnTriggerEnter2D(Collider2D collision)
    { 
         if (collision.attachedRigidbody.GetComponent<Entity>() != null )
              collision.attachedRigidbody.GetComponent<Entity>().AttackTarget(thisEntity); // apply damage to the collided enemy
                                                                                    // with values from thisEntity

           // Debug.Log("Cooll");//
    }




}
