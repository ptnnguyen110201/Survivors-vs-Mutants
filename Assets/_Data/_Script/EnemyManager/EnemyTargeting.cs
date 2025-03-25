using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : ObjectTargeting<EnemyCtrl>
{
    [SerializeField] protected List<int> lanes;
    [SerializeField] protected float distanceTarget;
    public virtual void UpdateLane()
    {
        this.lanes.Clear();
        if (this.lanes.Contains(this.objParent.Lane)) return;
        this.lanes.Add(this.objParent.Lane);
    }
    
    public virtual bool isTargeting()
    {
        List<CharacterCtrl> characterCtrls = CharacterManagerCtrl.Instance.CharacterManager.T_ListObj;
        CharacterCtrl closeCharacter = null;
        float minDistance = float.MaxValue;

        foreach (CharacterCtrl characterCtrl in characterCtrls)
        {
            if (this.objParent.Lane != characterCtrl.Lane) continue; 
            if (characterCtrl.IsSelecting) continue;
            float distance = Mathf.Abs(characterCtrl.transform.position.x - this.objParent.transform.position.x);

            if (distance < minDistance)
            {
                minDistance = distance;
                closeCharacter = characterCtrl;
            }
        }

        
        return closeCharacter != null && minDistance < this.distanceTarget;
    }

    public override void CheckTargeting()
    {
        if (!this.objParent.IsEnable) return;
        if (this.objParent.EnemyDamageReceiver.IsDead()) return;
        bool hasTarget = this.isTargeting();
        this.objParent.ObjectMove.SetCanMove(!hasTarget); 
        this.objParent.EnemyAttack.SetCanAttack(hasTarget); 
    }




}
