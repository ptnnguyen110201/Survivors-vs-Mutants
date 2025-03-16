using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterPutManager : Singleton<CharacterPutManager>
{
    [SerializeField] protected SelectedSlot selectedSlot;
    [SerializeField] protected Transform SpawnPoint;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadSpawnPoint() 
    {
        if (this.SpawnPoint != null) return;
        this.SpawnPoint = transform.Find("SpawnPoint").GetComponent<Transform>();
        this.SpawnPoint.gameObject.SetActive(false);    
        Debug.Log(transform.name + "Load SpawnPoint", gameObject);
    }


    protected virtual void Update()
    {
        this.HandleSpawnPoint();
        this.SpawnCharacter();

    }
    protected virtual void HandleSpawnPoint()
    {
        if (this.selectedSlot == null)
        {
            this.SpawnPoint.gameObject.SetActive(false);
            return;
        }

        if (this.IsPointerOverUI()) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        PlaceMap placeMap = MapManager.Instance.CurrentMap.PlacementMap.GetPlaceMap(mouseWorldPos);
        if (placeMap == null) return;

        Vector3 nearestPos = placeMap.GetNearestPlacePos(mouseWorldPos);
        this.SpawnPoint.position = nearestPos;
        this.SpawnPoint.gameObject.SetActive(true);
    }    
    protected virtual void SpawnCharacter()
    {
        if (this.selectedSlot == null) return;
        if (!GameManager.Instance.IsStart) return;
        if (this.IsPointerOverUI()) return;
        if (Input.GetMouseButtonUp(0))
        {
            CharacterManagerCtrl.Instance.CharacterSpawner.SpawnCharacter(this.selectedSlot.CharacterBuyProfile.characterProfile);
            this.DeductBuyCharacter();
            this.selectedSlot = null;
        }
    }

    protected virtual bool DeductBuyCharacter() 
    {
        ItemInventory itemGold = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Gold);
        if (itemGold == null) return false;
        itemGold.Deduct(this.selectedSlot.CharacterBuyProfile.chacracterCoints);
        return  true;
    }

    protected virtual bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();

    public virtual void SetSelectedSlot(SelectedSlot selectedSlot) => this.selectedSlot = selectedSlot;
}
