using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : ObjectMove<EnemyCtrl>
{
  
    public override void Moving()
    {
        transform.parent.Translate(this.moveSpeed * this.moveDirection * Time.fixedDeltaTime);

    }


}
