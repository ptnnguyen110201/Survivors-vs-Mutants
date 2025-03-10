using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : Spawner<CharacterCtrl>
{
    [SerializeField] protected Vector3 mousePosition;
    protected virtual void Update()
    {
        this.SpawnCharacter();
    }
    public virtual void SpawnCharacter()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);
            this.mousePosition = worldPos; 
            
            CharacterCtrl characterCtrl = this.poolPrefabs.GetPrefabByName("Char01");
            if (characterCtrl == null) return;

            Vector3 spawnPoint = MapManager.Instance.CurrentMap.PlacementMap.GetPlacePos(this.mousePosition);
            if (spawnPoint == Vector3.zero) return;
            CharacterCtrl newCharacter = this.Spawn(characterCtrl, spawnPoint);

            newCharacter.gameObject.SetActive(true);
        }


    }

}
