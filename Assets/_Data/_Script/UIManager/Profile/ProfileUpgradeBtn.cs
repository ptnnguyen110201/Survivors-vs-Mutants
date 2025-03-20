using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileUpgradeBtn : ButtonAbstract
{
    protected override void OnClick()
    {
        this.UpgradeCharacter();
    }

    protected void UpgradeCharacter() 
    {
        CharacterCtrl characterCtrl = ProfileManager.Instance.SelectedCharacterCtrl;
        if (characterCtrl == null) return;
        characterCtrl.CharacterLevel.levelUp();
    }
}