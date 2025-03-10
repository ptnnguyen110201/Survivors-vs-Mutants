using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargeting : ObjectTargeting<CharacterCtrl>
{
    [SerializeField] protected List<EnemyCtrl> enemyCtrls; 
    [SerializeField] protected BoxCollider2D boxCollider2D;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider2D();
    }
    public virtual bool isTargeting()
    {

        if (this.enemyCtrls.Count <= 0) return false;
        return true;
    }
    public override void CheckTargeting()
    {
        this.objParent.ObjectMove.SetCanMove(!this.isTargeting());
        this.objParent.ObjectAttack.SetCanAttack(this.isTargeting());
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        EnemyCtrl enemyCtrl = collider2D.transform.GetComponent<EnemyCtrl>();
        if (enemyCtrl == null) return;  
        if (this.enemyCtrls.Contains(enemyCtrl)) return;
        this.enemyCtrls.Add(enemyCtrl);

    }
    protected virtual void OnTriggerExit2D(Collider2D collider2D)
    {
        EnemyCtrl enemyCtrl = collider2D.transform.GetComponent<EnemyCtrl>();
        if(this.enemyCtrls.Contains(enemyCtrl))
        this.enemyCtrls.Remove(enemyCtrl);

    }

    protected virtual void LoadBoxCollider2D() 
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + ": Load BoxCollider2D", gameObject);
    }


}
