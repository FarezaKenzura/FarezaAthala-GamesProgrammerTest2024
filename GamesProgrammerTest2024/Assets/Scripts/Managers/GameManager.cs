using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    public TutorialManager tutorialManager;
    [SerializeField] private TutorialData dataEnemySpawn, dataPlayerSpawn, dataPlayerTurn;

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
                break;
            case GameState.SpawnEnemies:
                tutorialManager.SetUpTutorial(dataEnemySpawn);
                break;
            case GameState.SpawnCharacters:
                tutorialManager.SetUpTutorial(dataPlayerSpawn);
                break;
            case GameState.CharactersTurn:
                tutorialManager.SetUpTutorial(dataPlayerTurn);
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
}
