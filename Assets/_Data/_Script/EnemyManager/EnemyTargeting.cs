using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : ObjectTargeting<EnemyCtrl>
{
    [SerializeField] protected CircleCollider2D circleCollider2D;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }
    public virtual bool isTargeting()
    {

        if (this.objTargeting == null) return false;
        return true;
    }
    public override void CheckTargeting()
    {
        this.objParent.ObjectAttack.SetCanAttack(this.isTargeting());
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        CharacterCtrl characterCtrl = collider2D.transform.GetComponent<CharacterCtrl>();
        if (characterCtrl == null) return;
        this.SetObjTargeting(characterCtrl.transform);
        this.objParent.ObjectMove.SetCanMove(!this.isTargeting());
    }
    protected virtual void OnTriggerExit2D(Collider2D collider2D)
    {
        CharacterCtrl characterCtrl = collider2D.transform.GetComponent<CharacterCtrl>();
        if (characterCtrl == null) return;
        this.SetObjTargeting(null);
        this.objParent.ObjectMove.SetCanMove(!this.isTargeting());
    }
    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": Load CircleCollider2D", gameObject);
    }


}
