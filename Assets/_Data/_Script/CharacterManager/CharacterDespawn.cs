using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDespawn : Despawn<CharacterCtrl>
{
    protected override IEnumerator DespawnCoroutine()
    {
        yield break;
    }
}
