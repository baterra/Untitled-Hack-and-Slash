using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertAttackBox : MonoBehaviour {

    public int incomingAttacks = 0;

    public void OnTriggerStay2D(Collider2D collision)
    {

        incomingAttacks = 1;
    }

}
