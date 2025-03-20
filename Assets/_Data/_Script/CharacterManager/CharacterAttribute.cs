using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute : ObjectAttributes<CharacterCtrl>
{
    public override void GetAttributes()
    {
        int Level = this.ObjParent.CharacterLevel.GetCurrentLevel();
        CharacterProfile characterProfile = this.ObjParent.ObjectProfile as CharacterProfile;
        if (characterProfile == null) return;
        this.attributes = characterProfile.GetCharacterAttributes(Level);

    }

    public override void SetAttribute()
    {
        this.ObjParent.CharacterDamageReceiver.SetMaxHp(this.attributes.maxHP);  
        this.ObjParent.CharacterAttack.SetDamage(this.attributes.attackDamage);  
        this.ObjParent.CharacterAttack.SetCoolDownTime(this.attributes.fireRate);
        this.ObjParent.ObjectMove.SetMoveSpeed(this.attributes.moveSpeed);

    }

}
