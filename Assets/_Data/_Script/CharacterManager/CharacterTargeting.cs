using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargeting : ObjectTargeting<CharacterCtrl>
{
    [SerializeField] protected List<int> lanes;
    public List<int> Lanes => lanes;
    [SerializeField] protected float distanceTarget;
    [SerializeField] protected List<EnemyCtrl> enemyCtrls;
    public List<EnemyCtrl> EnemyCtrls => enemyCtrls;

    protected virtual void OnEnable() 
    {
        lanes.Clear();
        lanes.Add(objParent.Lane); 
    }
    public virtual bool isTargeting()
    {
        this.enemyCtrls = FindAnyObjectByType<EnemyManager>().GetEnemiesInLanes(this.lanes, transform.parent.position, distanceTarget);
        if (this.enemyCtrls.Count > 0) return true;
        return false;
    }

    public override void CheckTargeting()
    {

        this.objParent.ObjectMove.SetCanMove(!this.isTargeting());
        this.objParent.ObjectAttack.SetCanAttack(this.isTargeting());
    }



}
