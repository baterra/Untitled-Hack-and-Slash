using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {


    public EntityInfo entityInformation;
    public SpriteRenderer hpbar;

    private const float BAR_LENGTH = 0.723f;


	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(BAR_LENGTH * getPercentageHealth(), transform.localScale.y, transform.localScale.z);

    }
	
	// Update is called once per frame
	void Update () {
        float perc = getPercentageHealth();
        transform.localScale = new Vector3(BAR_LENGTH * perc, transform.localScale.y, transform.localScale.z);
        hpbar.material.color = new Color(1 - perc, perc,0, 1);
      




    }

    private float getPercentageHealth()
    {
        return  entityInformation.Health / entityInformation.getMaxHealth();
       
    }
}
