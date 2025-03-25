using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
[CreateAssetMenu(fileName = "MapProfile", menuName = "ScriptableObject/MapProfile", order = 2)]
public class MapProfile : ScriptableObject
{
    public int mapID;
    public List<MapWave> mapWaves;
    public float timeBeforeFirstWave;
   
}
