using UnityEngine;
using System.Collections;

public class DamageEventSubscriber : MonoBehaviour
{
    public TestEntity owner;

    // Use this for initialization
    void Start()
    {
        if(owner == null)
        {
            owner = GetComponent<TestEntity>();
        }

        if(owner != null)
        {
            // Subscribe
            //owner.OnTakeDamage += DoOnTakeDamage;
        }
    }

    void OnDisable()
    {
        if (owner != null)
        {
            // Unsubscribe
            //owner.OnTakeDamage -= DoOnTakeDamage;
        }
    }

    private void DoOnTakeDamage(object sender, Damage.DamageEventInfo info)
    {
        owner.applyHitstun();
        Debug.Log("REACTING TOO DAMAGE");

    }

}
