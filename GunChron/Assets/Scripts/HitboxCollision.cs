using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCollision : MonoBehaviour {
    public Entity thisEntity;
 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       

    }

 



    private void OnTriggerEnter2D(Collider2D collision)
    { 
         if (collision.attachedRigidbody.GetComponent<Entity>() != null )
              collision.attachedRigidbody.GetComponent<Entity>().AttackTarget(thisEntity);

           // Debug.Log("Cooll");//
    }




}
