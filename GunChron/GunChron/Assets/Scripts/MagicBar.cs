using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBar : MonoBehaviour {

    public EntityInfo entityInformation;
    public SpriteRenderer hpbar;
    private const float BAR_LENGTH = 0.554f;


    // Use this for initialization
    void Start()
    {
        //transform.localScale = new Vector3(BAR_LENGTH * getPercentageHealth(), transform.localScale.y, transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
        float perc = getPercentageMag();
        transform.localScale = new Vector3(BAR_LENGTH * perc, transform.localScale.y, transform.localScale.z);
        shiftColor(entityInformation.magic);



    }

    private float getPercentageMag()
    {
        return entityInformation.magic / entityInformation.getMaxMagic();

    }

    private void shiftColor(float magic)
    {
        if (magic < 250) // White color
        {
            hpbar.material.color = new Color32(255, 255, 255, 255);
            //Debug.Log("white");
            //Debug.Log(magic);
            return;
        }


        if (magic >= (250) && magic < (500)) // Cyan color////////
        {
            hpbar.material.color = new Color32(0, 255, 255, 255);
            //Debug.Log("cyan");
           // Debug.Log(magic);
            return;
        }


        if (magic >= (500) && magic < 750) // blue color
        {
            hpbar.material.color = new Color32(0, 0, 255, 255);
            //Debug.Log("blue");
            //Debug.Log(magic);
            return;
        }


        if (magic >= 750 ) // purple color
        {
            hpbar.material.color = new Color32(255, 0, 255, 255);
           // Debug.Log("purple");
           // Debug.Log(magic);
            return;
        }
    }
}
