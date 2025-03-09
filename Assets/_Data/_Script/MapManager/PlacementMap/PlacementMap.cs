using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;



public class PlacementMap : LoadComPonent
{
    [SerializeField] protected Tilemap tileMap;
    [SerializeField] protected List<Vector3> placePoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileMap();
        this.LoadPathPoints();
    }

    protected virtual void LoadTileMap()
    {
        if (this.tileMap != null) return;
        this.tileMap = transform.GetComponent<Tilemap>();
        Debug.Log(transform.name + ": Load TileMap", gameObject);
    }

    protected virtual void LoadPathPoints()
    {
        if (this.tileMap == null) return;

        this.placePoint.Clear();
        BoundsInt bounds = this.tileMap.cellBounds;

        Vector3 tileSize = tileMap.layoutGrid.cellSize;
        Vector3 offset = new Vector3(tileSize.x / 2, tileSize.y / 2, 0);

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (!this.tileMap.HasTile(cellPos)) continue;

                Vector3 worldPos = this.tileMap.CellToWorld(cellPos) + offset; 
                this.placePoint.Add(worldPos);
            }
        }
        Debug.Log(transform.name + ": Load PathPoints  " + this.placePoint.Count ,gameObject);
    }

    public virtual Vector3 GetPlacePos(Vector3 worldPosition) 
    {
        Vector3Int cellPosition = this.tileMap.WorldToCell(worldPosition);
        Vector3 tileWorldPos = this.tileMap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.5f, 0);
        if (!this.placePoint.Contains(tileWorldPos)) return Vector3.zero;
        return tileWorldPos;
    }
}


