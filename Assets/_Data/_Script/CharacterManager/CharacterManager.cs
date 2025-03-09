using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ObjectManager<CharacterCtrl>
{
    protected virtual void Update()
    {
        this.UpdateAction();
    }

    protected virtual void UpdateAction()
    {
        foreach (CharacterCtrl character in this.T_List)
        {
            if (!character.gameObject.activeSelf) return;
            character.ObjectTargeting.CheckTargeting();
            character.ObjectMove.Moving();
            character.ObjectAttack.Attacking();

        }
    }
}
