using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class InventoryTeset : LoadComPonent
{
    [ProButton]
    public virtual void AddItemTest(ItemEnum itemEnum,int Count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetInventoryCodeName(InventoryEnum.Items);
        for (int i = 0; i < Count; i++)
        {
            ItemInventory item = new()
            {
                itemCount = 1,
                itemProfileSO = InventoryManager.Instance.GetItemProfileSO(itemEnum)
            };
            inventoryCtrl.AddItem(item);
        }

    }
    [ProButton]
    public virtual void RemoveItemTest(ItemEnum itemEnum, int Count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetInventoryCodeName(InventoryEnum.Items);
        for (int i = 0; i < Count; i++)
        {
            ItemInventory item = new()
            {
                itemCount = 1,
                itemProfileSO = InventoryManager.Instance.GetItemProfileSO(itemEnum)
            };

            inventoryCtrl.RemoveItem(item);
        }


    }
    protected virtual void Start() 
    {
        this.AddCurrencyTest(ItemEnum.Gold, 1000);
    }

    [ProButton]
    public virtual void AddCurrencyTest(ItemEnum itemEnum, int Count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetInventoryCodeName(InventoryEnum.Currencies);

        for (int i = 0; i < Count; i++)
        {
            ItemInventory item = new()
            {
                itemCount = 1,
                itemProfileSO = InventoryManager.Instance.GetItemProfileSO(itemEnum)
            };

            inventoryCtrl.AddItem(item);
        }

    }
    [ProButton]
    public virtual void RemoveCurrencyTest(ItemEnum itemEnum,int Count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetInventoryCodeName(InventoryEnum.Currencies);
        for (int i = 0; i < Count; i++)
        {
            ItemInventory item = new()
            {
                itemCount = 1,
                itemProfileSO = InventoryManager.Instance.GetItemProfileSO(itemEnum)
            };

            inventoryCtrl.RemoveItem(item);
        }

    }
}
