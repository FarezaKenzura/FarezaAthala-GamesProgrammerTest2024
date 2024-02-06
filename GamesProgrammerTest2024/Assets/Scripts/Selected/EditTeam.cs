using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EditTeam : MonoBehaviour
{
    [SerializeField] private CharactersSelect charactersSelect;
    [SerializeField] private GameObject[] teamSlots;

    private List<SlotData> selectedCharacters = new List<SlotData>();

    private void Start()
    {
        foreach (var charStat in charactersSelect.charStats)
        {
            charStat.charbutton.onClick.AddListener(() => SelectCharacter(charStat.charData));
        }
        charactersSelect.ShowCharacterInformation(charactersSelect.charStats.Length > 0 ? charactersSelect.charStats[0].charData : null);
        charactersSelect.undoButton.onClick.AddListener(() => UndoSelectCharacter());
    }

    public void StartGame()
    {
        if (selectedCharacters.Count > 0)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.LogWarning("No character selected! Please select at least one character before starting the game.");
        }
    }

    public void SelectCharacter(CharactersData charData)
    {
        charactersSelect.ShowCharacterInformation(charData);
        PlayerPrefs.SetString("SelectedCharacter", charData.name);
        PlayerPrefs.Save();

        if (!IsCharacterSelected(charData))
        {
            GameObject emptySlot = FindEmptySlot();
            if (emptySlot != null)
            {
                GameObject characterObject = Instantiate(charData.characterPrefab, emptySlot.transform.position, Quaternion.identity);
                characterObject.transform.SetParent(emptySlot.transform);

                selectedCharacters.Add(new SlotData(charData, characterObject));
            }
            else
            {
                Debug.LogWarning("No available team slots.");
            }
        }
        else
        {
            Debug.LogWarning("Character already in the team.");
        }
    }

    public void UndoSelectCharacter()
    {
        if (selectedCharacters.Count > 0)
        {
            SlotData lastSelectedSlot = selectedCharacters[selectedCharacters.Count - 1];
            selectedCharacters.RemoveAt(selectedCharacters.Count - 1);

            DestroyImmediate(lastSelectedSlot.characterObject);
        }
    }

    private GameObject FindEmptySlot()
    {
        foreach (GameObject slot in teamSlots)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }

    private bool IsCharacterSelected(CharactersData charData)
    {
        return selectedCharacters.Exists(slot => slot.characterData == charData);
    }

    private class SlotData
    {
        public CharactersData characterData;
        public GameObject characterObject;

        public SlotData(CharactersData charData, GameObject charObject)
        {
            characterData = charData;
            characterObject = charObject;
        }
    }
}
