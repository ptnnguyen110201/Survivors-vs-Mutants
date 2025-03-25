using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargeting : ObjectTargeting<CharacterCtrl>
{
    [SerializeField] protected List<int> lanes;
    [SerializeField] protected float distanceTarget;
    [SerializeField] protected List<EnemyCtrl> enemyCtrls;


    public virtual void UpdateLane() 
    {
        this.lanes.Clear();
        if (this.lanes.Contains(this.objParent.Lane)) return;
        this.lanes.Add(this.objParent.Lane);
    }

    public virtual bool isTargeting()
    {
        if (this.objParent.IsSelecting) return false;
        this.enemyCtrls = EnemyManagerCtrl.Instance.EnemyManager.GetEnemiesInLanes(this.lanes, transform.parent.position, distanceTarget);
        if (this.enemyCtrls.Count > 0) return true;
        return false;
    }

    public override void CheckTargeting()
    {

        this.objParent.ObjectMove.SetCanMove(!this.isTargeting());
        this.objParent.CharacterAttack.SetCanAttack(this.isTargeting());
    }



}
