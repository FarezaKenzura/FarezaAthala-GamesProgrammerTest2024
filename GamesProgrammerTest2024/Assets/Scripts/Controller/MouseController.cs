using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject cursor;
    public float speed;
    public CharactersManager charactersManager;
    public EnemyManager enemyManager;
    private BaseCharacter character;

    private PathFinder pathFinder;
    private RangeFinder rangeFinder;
    private List<OverlayTile> path;
    private List<OverlayTile> rangeFinderTiles;
    private bool isMoving;
    
    private void Start()
    {
        pathFinder = new PathFinder();
        rangeFinder = new RangeFinder();

        path = new List<OverlayTile>();
        isMoving = false;
        rangeFinderTiles = new List<OverlayTile>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit2D? hit = GetFocusOnTile();

        if(hit.HasValue)
        {
            OverlayTile tile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();
            if (tile != null)
            {
                cursor.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z - 2);
                cursor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
            }

            if (rangeFinderTiles.Contains(tile) && !isMoving)
            {
                path = pathFinder.FindPath(character.standingOnTile, tile, rangeFinderTiles);
            }

            if (Input.GetMouseButtonDown(0))
            {
                tile.ShowTile();

                if (character == null)
                {
                    CharactersData characterData = charactersManager.GetSelectedCharacterData();
                    character = Instantiate(characterData.characterPrefab).GetComponent<BaseCharacter>();
                    //tile.gameObject.GetComponent<OverlayTile>().HideTile();
                    PositionCharacterOnLine(tile);
                    GetInRangeTiles();

                    GameManager.Instance.ChangeState(GameState.CharactersTurn);
                    charactersManager.CvnsCharcter.SetActive(false);
                }
                else
                {
                    Debug.Log("Move 1");
                    isMoving = true;
                    tile.gameObject.GetComponent<OverlayTile>().HideTile();
                }
            }

            if (Input.GetMouseButtonDown(1))
            {

                if (GameManager.Instance.GameState == GameState.SpawnEnemies)
                {
                    enemyManager.InitializeEnemy(tile);
                    GameManager.Instance.ChangeState(GameState.SpawnCharacters);
                }
            }
        }
        else
        {
            if (character != null)
            {
                GetInRangeTiles();
            }
        }

        if (isMoving && path.Count > 0)
        {
            MoveAlongPath();
        }
    }

    public void GetInRangeTiles()
    {
        rangeFinderTiles = rangeFinder.GetTileInRange(new Vector2Int(character.standingOnTile.gridLocation.x, character.standingOnTile.gridLocation.y), 2);

        foreach (var item in rangeFinderTiles)
        {
            item.ShowTile();
        }
    }

    private void MoveAlongPath()
    {
        var step = speed * Time.deltaTime;

        float zIndex = path[0].transform.position.z;
        character.transform.position = Vector2.MoveTowards(character.transform.position, path[0].transform.position, step);
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, zIndex);

        if(Vector2.Distance(character.transform.position, path[0].transform.position) < 0.00001f)
        {
            PositionCharacterOnLine(path[0]);
            path.RemoveAt(0);
        }

        if(path.Count == 0)
        {
            GetInRangeTiles();
            isMoving = false;
        }

    }

    public void PositionCharacterOnLine(OverlayTile tile)
    {
        character.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z - 1);
        character.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        character.standingOnTile = tile;
    }

    public RaycastHit2D? GetFocusOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2d, Vector2.zero);

        if(hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }
}
