using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditTeam : MonoBehaviour
{
    public CharactersSelect charactersSelect;
    public GameObject[] teamSlots;

    private void Start()
    {
        foreach (var charStat in charactersSelect.charStats)
        {
            charStat.charbutton.onClick.AddListener(() => SelectCharacter(charStat.charData));
        }
        charactersSelect.ShowCharacterInformation(charactersSelect.charStats.Length > 0 ? charactersSelect.charStats[0].charData : null);
    }
    
    public void SelectCharacter(CharactersData charData)
    {
        charactersSelect.ShowCharacterInformation(charData);
        
        GameObject emptySlot = FindEmptySlot();
        if (emptySlot != null)
        {
            GameObject character = Instantiate(charData.characterPrefab, emptySlot.transform.position, Quaternion.identity);
            character.transform.parent = emptySlot.transform;
        }
        else
        {
            Debug.LogWarning("No available team slots.");
        }
    }

    GameObject FindEmptySlot()
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
}
