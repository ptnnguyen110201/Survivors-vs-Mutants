using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class CharacterDamageReceiver : ObjectDamageReciever<CharacterCtrl>
{
 
    protected override void OnDead()
    {
        base.OnDead();
      //  this.objParent.ObjectAnimator.SetTriggerAnimation(this.HasDead);
    }

  
}

