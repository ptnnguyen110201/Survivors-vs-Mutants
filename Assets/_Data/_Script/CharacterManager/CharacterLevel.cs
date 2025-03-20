using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterLevel : ObjectLevel<CharacterCtrl>
{
    [SerializeField] protected ItemInventory itemInventory;
    [SerializeField] protected ItemRequirement nextRequirement;

    protected override void OnEnable()
    {
        this.currentLevel = 0;
        base.OnEnable();
    }

    protected virtual bool CanLevelUp()
    {
        if (this.itemInventory == null || this.nextRequirement == null) return false;
        if (this.GetItemInventory().itemCount < this.GetItemRequirement().itemCount) return false;
        this.GetItemInventory().Deduct(this.nextRequirement.itemCount);
        return true;
    }


    protected virtual void Update() 
    {
        this.GetItemRequirement();
        this.GetItemInventory();
    }
    public virtual ItemRequirement GetItemRequirement()
    {
        CharacterProfile characterProfile = this.ObjParent.ObjectProfile as CharacterProfile;
        if (characterProfile == null) return null;

        return this.nextRequirement = characterProfile.GetItemRequirement(this.currentLevel);
    }

    public virtual ItemInventory GetItemInventory()
    {
        if (this.nextRequirement == null) return this.itemInventory;
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetInventoryCodeName(this.nextRequirement.itemProfile.inventoryEnum);
        if (inventoryCtrl == null) return null;
        return this.itemInventory = inventoryCtrl.FindItem(this.nextRequirement.itemProfile.itemEnum);

    }

    public override void levelUp()
    {
        if (!this.CanLevelUp()) return;
    
        this.currentLevel++;
        this.ObjParent.CharacterAttribute.GetAttributes();
        this.ObjParent.CharacterAttribute.SetAttribute();
    }

    public override int GetMaxLevel()
    {
        CharacterProfile characterProfile = this.ObjParent.ObjectProfile as CharacterProfile;
        if (characterProfile == null) return 0;
        return this.maxLevel = characterProfile.charaterUpgrade.Count - 1;
    }

    public override int GetCurrentLevel() => this.currentLevel;

}
