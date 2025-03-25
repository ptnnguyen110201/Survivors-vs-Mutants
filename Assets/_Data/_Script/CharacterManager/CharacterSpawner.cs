using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : Spawner<CharacterCtrl>
{
    public virtual CharacterCtrl SpawnCharacter(CharacterProfile characterProfile, Vector3 MousePos)
    {
        CharacterCtrl characterCtrl = this.poolPrefabs.GetPrefabByName(characterProfile.characterName);
        if (characterCtrl == null) return null;

        CharacterCtrl newCharacter = this.Spawn(characterCtrl, MousePos);
        return newCharacter;

    }

}
