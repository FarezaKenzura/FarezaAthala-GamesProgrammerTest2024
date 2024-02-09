using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharactersInformation : MonoBehaviour
{
    public static CharactersInformation Instance;

    [Header("Information")]
    public TextMeshProUGUI nameText;
    public Image artWorkImage;
    public TextMeshProUGUI typeText;

    [Header("Stats")]
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI resText;

    void Awake()
    {
        Instance = this;
    }

    public void ShowCharacterInformation(CharactersData charData)
    {
        nameText.text = charData.nameChar;
        artWorkImage.sprite = charData.artWorkChar;
        typeText.text = charData.movementType.ToString();
        hpText.text = charData.hpStats.ToString();
        atkText.text = charData.atkStats.ToString();
        defText.text = charData.defStats.ToString();
        resText.text = charData.resStats.ToString();
    }
}
