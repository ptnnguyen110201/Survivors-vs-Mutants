using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;



public class PlacementMap : LoadComPonent
{
    [SerializeField] protected List<PlaceMap> placeMaps;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlaceMaps();
    }

    protected virtual void LoadPlaceMaps()
    {
        if (this.placeMaps.Count > 0) return;
        int laneIndex = 0;
        foreach (Transform obj in this.transform)
        {
            if (obj == null) continue;
            PlaceMap placeMap = obj.GetComponent<PlaceMap>();
            if (placeMap == null) continue;
            placeMap.LoadPoints();
            placeMap.SetMapLane(laneIndex);
            laneIndex++;
            this.placeMaps.Add(placeMap);
        }

        Debug.Log(transform.name + ": Load PathMaps:" + this.placeMaps.Count, gameObject);

    }

    public virtual PlaceMap GetPlaceMap(Vector3 mousePosition)
    {
        if (this.placeMaps.Count <= 0) return null;

        foreach (PlaceMap placeMap in this.placeMaps)
        {
            Vector3Int cellPosition = placeMap.Tilemap.WorldToCell(mousePosition);
            Vector3 tileWorldPos = placeMap.Tilemap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.5f, 0);
            if (!placeMap.Points.Contains(tileWorldPos)) continue;
            return placeMap;
        }
        return null;
    }



}


