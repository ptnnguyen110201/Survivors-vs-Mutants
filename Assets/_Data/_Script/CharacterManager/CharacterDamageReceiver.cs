using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class CharacterDamageReceiver : ObjectDamageReciever
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.objectAnimationEnum = ObjectAnimationEnum.IsDead;
    }
    protected override void OnDead()
    {
        base.OnDead();
        
    }

  
}

