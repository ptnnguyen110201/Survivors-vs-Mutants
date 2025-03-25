
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : ObjectManager<ItemDropCtrl>
{
    protected virtual void Update()
    {
        this.UpdateAction();
    }

    protected virtual void UpdateAction()
    {
        foreach (ItemDropCtrl itemDropCtrl in this.T_List)
        {
            if (!itemDropCtrl.gameObject.activeSelf) continue;
            ItemDropDespawn itemDropDespawn = itemDropCtrl.DespawnBase as ItemDropDespawn;
            if (itemDropDespawn == null) continue;
            itemDropDespawn.Timing();

        }
    }


    


}
