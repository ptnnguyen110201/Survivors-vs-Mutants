using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObject/ItemProfileSO", order = 1)]
public class ItemProfileSO : ScriptableObject
{
    public InventoryEnum inventoryEnum;
    public ItemEnum itemEnum;
   // public string itemName;
    public Sprite itemSprite;
    public bool isStackable = false; // So luong cua item nay co duoc cong don hay khong 
    public bool isUnlimitedStack = false; // Cho phep so luong cua item cong don khong co gioi han
}
