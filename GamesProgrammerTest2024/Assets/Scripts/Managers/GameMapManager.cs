using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapManager : MonoBehaviour
{
    public static GameMapManager Instance;
    [SerializeField] private int width, height;

    [SerializeField] private Tile forestTile, mountainTile, plainsTile, ruinsTile;
    [SerializeField] private Transform centerPoint;

    private Dictionary<Vector2, Tile> tiles;

    void Awake()
    {
        Instance = this;
    }

    public void GenerateMap()
    {
        Vector3 centerPosition = centerPoint.position;
        Vector3 offset = new Vector3(-(width - 1) / 2f, -(height - 1) / 2f, 0);

        tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 tilePosition = centerPosition + new Vector3(x, y, 0) + offset;

                int randomIndex = Random.Range(0, 4);
                Tile randomTile = null;

                switch (randomIndex)
                {
                    case 0:
                        randomTile = forestTile;
                        break;
                    case 1:
                        randomTile = mountainTile;
                        break;
                    case 2:
                        randomTile = plainsTile;
                        break;
                    case 3:
                        randomTile = ruinsTile;
                        break;
                }

                var spawnedTile = Instantiate(randomTile, tilePosition, Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(x, y);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        GameManager.Instance.ChangeState(GameState.SpawnCharacters);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(tiles.TryGetValue(pos, out var tile)){
            return tile;
        }
        return null;
    }
}
