using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ItemDropCtrl : PoolObj
{
    [SerializeField] protected InventoryEnum inventoryEnum = InventoryEnum.Items;
    public InventoryEnum InventoryEnum => inventoryEnum;

    [SerializeField] protected ItemEnum itemEnum;
    public ItemEnum ItemEnum => itemEnum;
    [SerializeField] protected int itemCount = 1;
    public int ItemCount => itemCount;


 
    public virtual void SetValue(ItemEnum itemEnum, int itemCount,InventoryEnum inventoryEnum)
    {
        this.itemEnum = itemEnum;
        this.itemCount = itemCount;
        this.inventoryEnum = inventoryEnum;
    }
   

}
