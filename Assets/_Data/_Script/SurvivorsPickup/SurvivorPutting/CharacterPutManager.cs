using UnityEngine;

public class CharacterPutManager : Singleton<CharacterPutManager>
{
    [SerializeField] protected CharacterCtrl selectedCharacter;
    public CharacterCtrl SelectedCharacter => selectedCharacter;


    [SerializeField] protected bool isTranslating = false;
    public bool IsTranslating => isTranslating;   

    [SerializeField] protected SpriteRenderer spawnPoint;
    [SerializeField] protected Vector3 savedPosition;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = transform.Find("SpawnPoint").GetComponent<SpriteRenderer>();
        this.spawnPoint.gameObject.SetActive(false);
        Debug.Log(transform.name + " Load SpawnPoint", gameObject);
    }

    protected virtual void Update()
    {
        this.HandleKeyTranslate();
        this.HandleSpawnPoint();
        this.HandleTranslate();
        this.HandlePlacement();
    }

    protected virtual void HandlePlacement()
    {
        if (!this.isTranslating || this.selectedCharacter == null) return;

        if (InputManager.Instance.leftMouse)
        {
            Vector3 mouseWorldPosition = InputManager.Instance.mouseWolrdPos;
            mouseWorldPosition.z = 0;

            PlaceMap placeMap = MapManager.Instance.CurrentMap.PlacementMap.GetPlaceMap(mouseWorldPosition);
            if (placeMap == null) return;

            Vector3 spawnPosition = placeMap.GetPlacePos(mouseWorldPosition);
            CharacterCtrl hitCharacter = CharacterManagerCtrl.Instance.CharacterManager.isExistCharacter(spawnPosition);

            if (hitCharacter == null)
            {
                this.selectedCharacter.SetLane(placeMap.GetMapLane());
                this.selectedCharacter.SetPos(spawnPosition);
                this.SetSelectSurvivorCtrl();
                return;
            }
            CharacterFushionManager.Instance.Fushion(this.selectedCharacter, hitCharacter);
            this.SetSelectSurvivorCtrl(); 
            return;

        }
    }

    protected virtual void HandleTranslate()
    {
        if (!this.isTranslating || this.selectedCharacter == null) return;
        this.selectedCharacter.transform.position = InputManager.Instance.mouseWolrdPos;
    }

    protected virtual void HandleKeyTranslate()
    {
        if (InputKeyManager.Instance.isKeyM)
            this.isTranslating = !this.IsTranslating;

        if (!InputManager.Instance.rightMouse) return;
            this.SetSelectSurvivorCtrl();
    }

    protected virtual void HandleSpawnPoint()
    {
        if (this.selectedCharacter == null)
        {
            CharacterFushionManager.Instance.HideAllFusionIcons();
            this.spawnPoint.gameObject.SetActive(false);
            return;
        }

        Vector3 mouseWorldPosition = InputManager.Instance.mouseWolrdPos;
        mouseWorldPosition.z = 0;

        PlaceMap placeMap = MapManager.Instance.CurrentMap.PlacementMap.GetPlaceMap(mouseWorldPosition);
        if (placeMap == null) return;

        Vector3 nearestPosition = placeMap.GetPlacePos(mouseWorldPosition);
        this.spawnPoint.transform.position = nearestPosition;

        CharacterProfile selectedProfile = this.selectedCharacter.ObjectProfile as CharacterProfile;
        bool isOccupied = CharacterManagerCtrl.Instance.CharacterManager.isExistCharacter(nearestPosition) != null;

        this.spawnPoint.sprite = selectedProfile.characterSprite;
        this.spawnPoint.gameObject.SetActive(!isOccupied);

        CharacterProfile characterProfile = this.selectedCharacter.ObjectProfile as CharacterProfile;
        CharacterFushionManager.Instance.ShowCanFushion(characterProfile);
    }

    public virtual void SetSelectSurvivorSlot(CharacterProfile characterProfile = null)
    {
        if (characterProfile == null)
        {
            this.selectedCharacter = null;
            return;
        }

        this.selectedCharacter = CharacterManagerCtrl.Instance.CharacterSpawner.PoolPrefabs.GetPrefabByName(characterProfile.characterName);
    }

    public virtual void SetSelectSurvivorCtrl(CharacterCtrl characterCtrl = null)
    {
        if (characterCtrl == null)
        {
            this.isTranslating = false;
            this.selectedCharacter.SetIsFushioning();
            this.selectedCharacter = null;
            return;
        }
        this.savedPosition = characterCtrl.transform.position;
        this.selectedCharacter = characterCtrl;
        this.selectedCharacter.SetIsFushioning(true);
    }
}
