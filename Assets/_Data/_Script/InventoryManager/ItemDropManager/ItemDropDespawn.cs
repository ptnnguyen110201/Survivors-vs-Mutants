using System.Collections;

public class ItemDropDespawn : DespawnByTime<ItemDropCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByTime = true;
    }
    public override void DespawnObj() 
    {
        ItemDropCtrl itemdropCtrl = (ItemDropCtrl)this.parent;
        ItemInventory item = new ItemInventory()
        {
            itemProfileSO = InventoryManager.Instance.GetItemProfileSO(itemdropCtrl.ItemEnum),
            itemCount = itemdropCtrl.ItemCount  
        };
        InventoryManager.Instance.GetInventoryCodeName(itemdropCtrl.InventoryEnum).AddItem(item);
        base.DespawnObj();
    }

  
}
