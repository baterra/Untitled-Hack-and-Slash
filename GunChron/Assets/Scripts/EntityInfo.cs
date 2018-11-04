using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityInfo : MonoBehaviour {
    public int level;
    public float magic;
    public float Stag;
    public float Health;
  

    //public GameObject[] entityForms = new GameObject[3];
    
    
    // Use this for initialization

    public EntityInfo()
    {
        level = 0;
        magic = 0;
        Stag = 0;
        Health = 500;
    }

    public EntityInfo(int lv, float mg, float stg, float hp)
    {
        level = lv;
        magic = mg;
        Stag = stg;
        Health = hp;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject spawnEntity()
    {
       return null;
    }



    abstract public float getMaxHealth();
    abstract public float getMaxStag();
    abstract public float getMaxMagic();

    abstract public void loseHealth(float h);
    abstract public void gainHealth(float h);
    abstract public void gainStag(float s);
    abstract public void loseStag(float s);
    abstract public void gainMagic(float m);
    abstract public void loseMagic(float m);



}
