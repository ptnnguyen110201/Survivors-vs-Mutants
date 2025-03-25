using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDespawn : Despawn<CharacterCtrl>
{
    public override void DespawnObj()
    {
        CharacterManagerCtrl.Instance.CharacterManager.UnRegisterObject(this.parent);
        base.DespawnObj();
    }
}
