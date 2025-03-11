using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : ObjectTargeting<EnemyCtrl>
{
    [SerializeField] protected float distanceTarget;
    public virtual bool isTargeting()
    {
        List<CharacterCtrl> characterCtrls = FindAnyObjectByType<CharacterManager>().T_ListObj;
        CharacterCtrl closeCharacter = null;
        float minDistance = float.MaxValue;

        foreach (CharacterCtrl characterCtrl in characterCtrls)
        {
            if (this.objParent.Lane != characterCtrl.Lane) continue; 

            float distance = Mathf.Abs(characterCtrl.transform.position.x - this.objParent.transform.position.x);

            if (distance < minDistance)
            {
                minDistance = distance;
                closeCharacter = characterCtrl;
            }
        }

  
        return closeCharacter != null && minDistance < distanceTarget;
    }

    public override void CheckTargeting()
    {
        if (this.objParent.EnemyDamageReceiver.IsDead()) return;
        bool hasTarget = this.isTargeting();
        this.objParent.ObjectMove.SetCanMove(!hasTarget); 
        this.objParent.ObjectAttack.SetCanAttack(hasTarget); 
    }




}
