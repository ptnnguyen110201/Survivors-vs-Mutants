using System;
[Serializable]
public class ItemInventory 
{
    public int itemID;
    public ItemProfileSO itemProfileSO;
    public int itemCount;
    public int itemStack = 99; // so luong cho phep cong don
    public virtual bool Deduct(int Amount) 
    {
        if(this.itemCount < Amount) return false;
        this.itemCount -= Amount;
        return true;
    }
    public bool isFullStack()
    {
        if (this.itemProfileSO.isUnlimitedStack) return false; 
        return this.itemCount >= this.itemStack;
    }


}
