using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : ObjectModel<EnemyCtrl>
{
    public override void ApplyEffect()
    {
        this.SpriteByEffect();
    }
}
