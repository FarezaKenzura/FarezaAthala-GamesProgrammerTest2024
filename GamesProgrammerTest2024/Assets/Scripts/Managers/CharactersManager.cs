using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CharactersManager : MonoBehaviour
{
    public CharStats[] charStats;
    public GameObject CvnsCharcter;
    
    private CharactersData selectedCharacterData;
    public CharactersData GetSelectedCharacterData() { return selectedCharacterData; }

    void Start()
    {
        foreach (CharStats stats in charStats)
        {
            stats.charbutton.onClick.AddListener(() => OnCharacterButtonClicked(stats.charData));
        }

        ShowInitialCharacterInformation();
    }

    void ShowInitialCharacterInformation()
    {
        if (charStats.Length > 0)
        {
            CharactersInformation.Instance.ShowCharacterInformation(charStats[0].charData);
            selectedCharacterData = charStats[0].charData;
        }
    }

    private void OnCharacterButtonClicked(CharactersData charData)
    {
        CharactersInformation.Instance.ShowCharacterInformation(charData);
        selectedCharacterData = charData;
    }
}

[Serializable]
public class CharStats
{
    public Button charbutton;
    public CharactersData charData;
}
