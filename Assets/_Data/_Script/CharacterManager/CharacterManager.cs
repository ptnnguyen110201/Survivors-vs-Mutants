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
            if (!character.gameObject.activeSelf) continue;
            character.CharacterTargeting.UpdateLane();
            character.CharacterTargeting.CheckTargeting();
            character.ObjectMove.Moving();
            character.CharacterAttack.Attacking(); 
        }
    }

    public virtual CharacterCtrl isExistCharacter(Vector3 spawnPos)
    {
        if (this.T_List.Count <= 0) return null;
        foreach (CharacterCtrl characterCtrl in this.T_List)
        {
            if (characterCtrl.transform.position == spawnPos) return characterCtrl;
        }
        return null;
    }

}
