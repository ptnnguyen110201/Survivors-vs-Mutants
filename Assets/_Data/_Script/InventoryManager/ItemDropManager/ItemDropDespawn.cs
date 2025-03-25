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
        base.DespawnObj();
        this.DropByDespawn();
    }
    protected virtual void DropByDespawn() 
    {
        ItemInventory item = new ItemInventory()
        {
            itemProfileSO = InventoryManager.Instance.GetItemProfileSO(this.parent.ItemEnum),
            itemCount = this.parent.ItemCount  
        };
        InventoryManager.Instance.GetInventoryCodeName(this.parent.InventoryEnum).AddItem(item);

    }

  
}
