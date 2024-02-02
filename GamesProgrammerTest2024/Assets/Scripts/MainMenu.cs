using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Enum to define different states
    public enum MenuState
    {
        Start,
        Credits,
        Exit
    }

    // Current state variable
    private MenuState currentState;

    // UI buttons for Main Menu
    [Header("UI Button")]
    public Button startButton;
    public Button creditsButton;
    public Button exitButton;

    [Header("UI Panel")]
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;

    void Start()
    {
        startButton.onClick.AddListener(() => SetState(MenuState.Start));
        creditsButton.onClick.AddListener(() => SetState(MenuState.Credits));
        exitButton.onClick.AddListener(() => SetState(MenuState.Exit));
    }

    void SetState(MenuState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case MenuState.Start:  
                SceneManager.LoadScene("SetParty");
                break;
            case MenuState.Credits: 
                EnablePanel(creditsPanel); 
                DisablePanel(mainMenuPanel);
                break;
            case MenuState.Exit: 
                Application.Quit(); 
                break;
        }
    }

    void EnablePanel(GameObject panel) => panel.SetActive(true);

    void DisablePanel(GameObject panel) => panel.SetActive(false);
}
