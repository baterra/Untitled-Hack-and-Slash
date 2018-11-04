using UnityEngine;
using System.Collections;


public static class Damage
{

    public struct DamageEventInfo
    {
        public float damageValue;
        public DamageType type;
        //float air;
        //float water;
        //float cold;
        //float fire;
        //float thunder;
        //float dark;
        //float holy;
        //float ether;
        //float nonelement;
        //float stag;
        //float physical;
        //float magicDrain;
        public DamageEventInfo(float _dmg, DamageType _type)
        {
            damageValue = _dmg;
            type = _type;
        }
    }

    public enum DamageType
    {
        Physical,
        Air,
        Water,
        Cold,
        Fire
    }
}
