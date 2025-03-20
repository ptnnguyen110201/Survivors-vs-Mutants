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
            character.CharacterTargeting.CheckTargeting();
            character.ObjectMove.Moving();
            character.CharacterAttack.Attacking(); 
        }
    }
    public virtual bool isExistPlace(Vector3 spawnPos) 
    {
        if(this.T_List.Count <= 0) return false;
        foreach(CharacterCtrl characterCtrl in this.T_List) 
        {
            if (characterCtrl.transform.position == spawnPos) return true;
        }
        return false;
    }


}
