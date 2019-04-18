using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerBar : MonoBehaviour {

    public EntityInfo entityInformation;
    public SpriteRenderer bar;

    private const float BAR_LENGTH = 0.723f;


    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(BAR_LENGTH * getPercentageStag(), transform.localScale.y, transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
        float perc = getPercentageStag();
        transform.localScale = new Vector3(BAR_LENGTH * perc, transform.localScale.y, transform.localScale.z);
        bar.material.color = new Color(1 , 1 - perc, 1 - perc, 1);





    }

    private float getPercentageStag()
    {
        return entityInformation.Stag / entityInformation.getMaxStag();

    }
}
