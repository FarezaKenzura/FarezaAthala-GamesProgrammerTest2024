using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject cnvsTutorial;
    
    [SerializeField] private TextMeshProUGUI txttutorial;

    [SerializeField] private Image imgTutorial;

    [SerializeField] private Button btnNext;

    [Header("Data")]

    private TutorialData currentTutorialData;
    private int index;

    private void Awake()
    {
        btnNext.onClick.AddListener(NextTutorial);
    }

    public void SetUpTutorial(TutorialData data)
    {
        cnvsTutorial.SetActive(true);
        currentTutorialData = data;
        index = 0;
        NextTutorial();
    }

    private void NextTutorial()
    {
        if (currentTutorialData != null && index < currentTutorialData.Data.Length)
        {
            txttutorial.SetText(currentTutorialData.Data[index].ContentTutor);

            if (currentTutorialData.Data[index].PictureTutor != null)
            {
                imgTutorial.sprite = currentTutorialData.Data[index].PictureTutor;
                imgTutorial.enabled = true;
            }
            else
            {
                imgTutorial.enabled = false;
            }

            index++;
        }
        else
        {
            EndTutorial();
        }
    }

    private void EndTutorial()
    {
        cnvsTutorial.SetActive(false);
    }
}
