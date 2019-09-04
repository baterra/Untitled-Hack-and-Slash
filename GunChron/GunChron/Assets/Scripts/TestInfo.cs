using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInfo : EntityInfo
{
    public TestInfo(int lv, float mg, float stg, float hp)
    {
        level = lv;
        magic = mg;
        Stag = stg;
        Health = hp;

    }



   //******************************
    // Stats related Methods
  // ******************************

    override
    public float getMaxHealth()
    {
        return 500 + 500 * (level);
    }

    override
    public float getMaxStag()
    {
        return 250 + 500 * (level);
    }

    override
    public float getMaxMagic()
    {
        return 750;
    }

    override
    public void loseHealth(float h)
    {
        Health = Health - h;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    override
    public void gainHealth(float h)
    {
        Health = Health + h;

        if (Health > getMaxHealth())
        {
            Health = getMaxHealth();
        }
    }

    override
    public void gainStag(float s)
    {
        Stag = Stag + s;

        if (Stag > getMaxStag())
        {
            Stag = getMaxStag();
        }
    }

    override
     public void loseStag(float s)
    {
        Stag = Stag - s;

        if (Stag < 0)
        {
            Stag = 0;
        }
    }

    override
    public void gainMagic(float m)
    {
        magic = magic + m;

        if (magic > getMaxMagic())
        {
            magic = getMaxMagic();
        }
    }

    override
    public void loseMagic(float m)
    {
        magic = magic - m;

        if (magic < 0)
        {
            magic = 0;
        }
    }
}
