using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : ObjectTargeting<EnemyCtrl>
{
    [SerializeField] protected CharacterCtrl objTargeting;
    public virtual void SetObjTargeting(CharacterCtrl objTargeting) => this.objTargeting = objTargeting;

    public virtual bool isTargeting() 
    {
        if(this.objTargeting == null) return false;
        return true;
    }
    public override void CheckTargeting()
    {
        this.objParent.ObjectMove.SetCanMove(!this.isTargeting());
        this.objParent.ObjectAttack.SetCanAttack(this.isTargeting());
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D) 
    {
        CharacterCtrl characterCtrl = collider2D.GetComponent<CharacterCtrl>();
        if (characterCtrl == null) return;
        this.SetObjTargeting(characterCtrl);
    }
    protected virtual void OnTriggerExit2D(Collider2D collider2D)
    {
        CharacterCtrl characterCtrl = collider2D.GetComponent<CharacterCtrl>();
        if (characterCtrl == null) return;
        this.SetObjTargeting(null);
    }

   
}
