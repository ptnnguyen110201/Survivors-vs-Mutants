using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class CharacterDamageReceiver : ObjectDamageReciever
{
    [SerializeField] protected CharacterCtrl characterCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterCtrl();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.objectAnimationEnum = ObjectAnimationEnum.IsDead;
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.characterCtrl.DespawnBase.DespawnObj();
        
    }
    protected virtual void LoadCharacterCtrl()
    {
        if (this.characterCtrl != null) return;
        this.characterCtrl = transform.GetComponentInParent<CharacterCtrl>(true);
        Debug.Log(transform.name + ": Load CharacterCtrl", gameObject);
    }

}

