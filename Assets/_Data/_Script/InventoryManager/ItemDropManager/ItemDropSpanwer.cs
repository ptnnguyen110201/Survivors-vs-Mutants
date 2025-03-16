using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpanwer : Spawner<ItemDropCtrl>
{
    public virtual void DropItems(InventoryEnum inventoryEnum, ItemEnum itemEnum, int dropCount, Vector3 DropPos)
    {
        ItemDropCtrl itemPrefab = this.PoolPrefabs.GetPrefabByName(itemEnum.ToString());
        ItemDropCtrl newItem = this.Spawn(itemPrefab, DropPos);
        newItem.SetValue(itemEnum, dropCount, inventoryEnum);
        newItem.gameObject.SetActive(true);
    }
}
