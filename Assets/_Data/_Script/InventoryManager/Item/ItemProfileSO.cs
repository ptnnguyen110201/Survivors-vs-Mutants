using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObject/ItemProfileSO", order = 1)]
public class ItemProfileSO : ObjectProfile
{
    public InventoryEnum inventoryEnum;
    public ItemEnum itemEnum;
    public bool isStackable = false;
    public bool isUnlimitedStack = false; 
}
