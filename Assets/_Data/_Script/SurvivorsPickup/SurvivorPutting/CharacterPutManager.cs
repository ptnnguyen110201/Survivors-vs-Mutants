using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterPutManager : Singleton<CharacterPutManager>
{
    [SerializeField] protected CharacterBuyProfile characterBuyProfile;
    [SerializeField] protected SpriteRenderer SpawnPoint;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadSpawnPoint()
    {
        if (this.SpawnPoint != null) return;
        this.SpawnPoint = transform.Find("SpawnPoint").GetComponent<SpriteRenderer>();
        this.SpawnPoint.gameObject.SetActive(false);
        Debug.Log(transform.name + "Load SpawnPoint", gameObject);
    }


    protected virtual void Update()
    {
        this.HandleSpawnPoint();

    }
      protected virtual void HandleSpawnPoint()
      {
          if (this.characterBuyProfile == null)
          {
              this.SpawnPoint.gameObject.SetActive(false);
              return;
          }

          if (!this.IsPointerOverUI()) return;

          Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          mouseWorldPos.z = 0;

          PlaceMap placeMap = MapManager.Instance.CurrentMap.PlacementMap.GetPlaceMap(mouseWorldPos);
          if (placeMap == null) return;

          Vector3 nearestPos = placeMap.GetNearestPlacePos(mouseWorldPos);
          this.SpawnPoint.transform.position = nearestPos;
          this.SpawnPoint.sprite = this.characterBuyProfile.characterProfile.characterSprite;
          this.SpawnPoint.gameObject.SetActive(true);
      }
      public virtual void SpawnCharacter()
      {
          if (this.characterBuyProfile == null) return;
          bool canPut = CharacterManagerCtrl.Instance.CharacterSpawner.SpawnCharacter(this.characterBuyProfile.characterProfile);
          if (!canPut) return;
          this.DeductBuyCharacter();
          this.characterBuyProfile = null;

      }

      protected virtual bool DeductBuyCharacter()
      {
          ItemInventory itemGold = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Gold);
          if (itemGold == null) return false;
          itemGold.Deduct(this.characterBuyProfile.chacracterCoints);
          return true;
      }

      protected virtual bool IsPointerOverUI() => !EventSystem.current.IsPointerOverGameObject();

    public virtual void SetSelectSurvivorSlot(CharacterBuyProfile characterBuyProfile = null) => this.characterBuyProfile = characterBuyProfile;
   
}

