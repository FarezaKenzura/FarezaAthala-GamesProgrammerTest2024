using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateMap);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateMap:
                GameMapManager.Instance.GenerateMap();
                break;
            case GameState.SpawnCharacters:
                //UnitManager.Instance.SpawnHeroes();
                break;
            case GameState.SpawnEnemies:
                //UnitManager.Instance.SpawnEnemies();
                break;
            case GameState.CharactersTurn:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateMap,
    SpawnCharacters,
    SpawnEnemies,
    CharactersTurn,
    EnemiesTurn
}
