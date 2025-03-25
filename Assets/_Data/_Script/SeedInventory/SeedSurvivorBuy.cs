
using UnityEngine;



public class SeedSurvivorBuy : Singleton<SeedSurvivorBuy>
{
    [SerializeField] protected CharacterBuyProfile characterBuyProfile;

    public virtual void BuyCharacter()
    {
        if (this.characterBuyProfile == null) return;
        Vector3 mouseWorldPosition = InputManager.Instance.mouseWolrdPos;
        PlaceMap placeMap = MapManager.Instance.CurrentMap.PlacementMap.GetPlaceMap(mouseWorldPosition);
        if (placeMap == null) return;

        Vector3 spawnPosition = placeMap.GetPlacePos(mouseWorldPosition);
        if (spawnPosition == Vector3.zero) return;

        CharacterCtrl hitCharacter = CharacterManagerCtrl.Instance.CharacterManager.isExistCharacter(spawnPosition);
        CharacterCtrl newCharacter = CharacterManagerCtrl.Instance.CharacterSpawner.SpawnCharacter(characterBuyProfile.characterProfile, spawnPosition);
        if (hitCharacter == null) 
        {
            newCharacter.SetLane(placeMap.GetMapLane());
            newCharacter.gameObject.SetActive(true); 
            this.DeductBuyCharacter();
        }
        bool canfushion = CharacterFushionManager.Instance.Fushion(newCharacter, hitCharacter);
        if (!canfushion) return;
        this.DeductBuyCharacter();




    }


    protected virtual bool DeductBuyCharacter()
    {
        ItemInventory itemGold = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Gold);
        if (itemGold == null) return false;
        itemGold.Deduct(this.characterBuyProfile.chacracterCoints);
        return true;
    }

    public virtual void SetSelectSurvivorSlot(CharacterBuyProfile characterBuyProfile = null) => this.characterBuyProfile = characterBuyProfile;

}
