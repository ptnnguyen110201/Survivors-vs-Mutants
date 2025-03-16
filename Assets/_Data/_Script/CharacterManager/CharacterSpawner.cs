using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : Spawner<CharacterCtrl>
{
    [SerializeField] protected Vector3 mousePosition;

    public virtual void SpawnCharacter(CharacterProfile characterProfile)
    {

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        this.mousePosition = worldPos;

        CharacterCtrl characterCtrl = this.poolPrefabs.GetPrefabByName(characterProfile.characterName);
        if (characterCtrl == null) return;

        PlaceMap placeMap = MapManager.Instance.CurrentMap.PlacementMap.GetPlaceMap(this.mousePosition);
        if (placeMap == null) return;

        Vector3 spawnPos = placeMap.GetPlacePos(this.mousePosition);
        if (spawnPos == Vector3.zero) return;

        CharacterCtrl newCharacter = this.Spawn(characterCtrl, spawnPos);
        newCharacter.SetLane(placeMap.GetMapLane());
        newCharacter.gameObject.SetActive(true);



    }

}
