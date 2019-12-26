using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEventManager : MonoBehaviour
{
    public delegate void AnimationEvents();

    public AnimationEvents animEvents;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animEvents != null)
        {
            animEvents();
        }
    }
}
