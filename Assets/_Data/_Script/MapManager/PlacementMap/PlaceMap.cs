using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceMap : LoadComPonent
{
    [SerializeField] protected int mapLane;
    [SerializeField] protected Tilemap tileMap;
    public Tilemap Tilemap => tileMap;
    [SerializeField] protected List<Vector3> points;
    public List<Vector3> Points => points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileMap();
        this.LoadPoints();
    }

    protected virtual void LoadTileMap()
    {
        if (this.tileMap != null) return;
        this.tileMap = transform.GetComponent<Tilemap>();
        Debug.Log(transform.name + ": Load TileMap", gameObject);
    }

    public virtual void LoadPoints()
    {
       
        if (this.tileMap == null) return;

        this.Points.Clear();
        BoundsInt bounds = this.tileMap.cellBounds;
        Vector3 tileSize = this.tileMap.layoutGrid.cellSize;
        Vector3 offset = new Vector3(tileSize.x / 2, tileSize.y / 2, 0);

        for (int x = bounds.xMax - 1; x >= bounds.xMin; x--)
        {
            for (int y = bounds.yMax - 1; y >= bounds.yMin; y--)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (!this.tileMap.HasTile(cellPos)) continue;

                Vector3 worldPos = this.tileMap.CellToWorld(cellPos) + offset;
                this.Points.Add(worldPos);
            }
        }
        Debug.Log(transform.name + ": Load Point", gameObject);
    }


    public virtual void SetMapLane(int mapLane) => this.mapLane = mapLane;
    public virtual int GetMapLane() => this.mapLane;

    public virtual Vector3 GetPlacePos(Vector3 worldPosition)
    {
        Vector3Int cellPosition = this.tileMap.WorldToCell(worldPosition);
        Vector3 tileWorldPos = this.tileMap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.5f, 0);

        if (this.points.Contains(tileWorldPos))
            return tileWorldPos;

        return GetNearestPlacePos(worldPosition);
    }
    public virtual Vector3 GetNearestPlacePos(Vector3 worldPosition)
    {
        if (this.points.Count == 0) return Vector3.zero;

        float minDistance = float.MaxValue;
        Vector3 nearestPoint = Vector3.zero;

        foreach (Vector3 point in this.points)
        {
            float distance = Vector3.Distance(worldPosition, point);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPoint = point;
            }
        }

        return nearestPoint;
    }
}
