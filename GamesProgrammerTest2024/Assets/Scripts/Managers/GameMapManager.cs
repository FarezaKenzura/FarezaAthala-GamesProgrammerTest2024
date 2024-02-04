using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapManager : MonoBehaviour
{
    [Header("Map")]
    public Vector2Int size;
    public Vector2 offsetTile;
    public Vector2 offsetBoard;
    
    public GameObject tilePrefab;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector2 tilePosition = new Vector2(x * offsetTile.x, y * offsetTile.y) + offsetBoard;

                // Instantiate your tile prefab at 'tilePosition' and set the current object as the parent
                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, this.gameObject.transform);

                // Set a different color for each tile based on its position
                Color tileColor = new Color(x / (float)size.x, y / (float)size.y, 1f);
                tile.GetComponent<Renderer>().material.color = tileColor;

                // Set a name for the tile based on its position
                tile.name = $"Tile_{x}_{y}";
            }
        }
    }
}
