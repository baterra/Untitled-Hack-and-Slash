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
        Physical, // 0
        Air, // 1
        Water, // 2
        Cold, // 3
        Fire, // 4
        Thunder, // 5
        Dark, // 6
        Holy, // 7
        Ether, // 8
        NonElement, // 9
        //Stag, // 10
        //MagicDrain // 11
    }
}
