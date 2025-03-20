using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : Spawner<CharacterCtrl>
{
    [SerializeField] protected Vector3 mousePosition;

    public virtual bool SpawnCharacter(CharacterProfile characterProfile)
    {

        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mousePosition.z = 0;

        CharacterCtrl characterCtrl = this.poolPrefabs.GetPrefabByName(characterProfile.characterName);
        if (characterCtrl == null) return false;

        PlaceMap placeMap = MapManager.Instance.CurrentMap.PlacementMap.GetPlaceMap(this.mousePosition);
        if (placeMap == null) return false;

        Vector3 spawnPos = placeMap.GetPlacePos(this.mousePosition);
        if (spawnPos == Vector3.zero) return false; ;

        bool isExistPlace = CharacterManagerCtrl.Instance.CharacterManager.isExistPlace(spawnPos);
        if (isExistPlace) return false;
        CharacterCtrl newCharacter = this.Spawn(characterCtrl, spawnPos);
        newCharacter.SetLane(placeMap.GetMapLane());
        newCharacter.gameObject.SetActive(true);


        return true;

    }

}
