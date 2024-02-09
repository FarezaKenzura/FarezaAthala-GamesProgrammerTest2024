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
                MapManager.instance.GenerateMap();
                break;
            case GameState.SpawnEnemies:
                break;
            case GameState.SpawnCharacters:
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
