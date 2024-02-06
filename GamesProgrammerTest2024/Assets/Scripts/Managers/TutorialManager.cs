using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialData datatutorial;
    
    [Header("UI")]
    [SerializeField] private GameObject cnvsTutorial;
    
    [SerializeField] private TextMeshProUGUI txttutorial;

    [SerializeField] private Image imgTutorial;

    [SerializeField] private Button btnNext;

    private int index;

    private void Awake()
    {
        btnNext.onClick.AddListener(NextTutorial);
    }

    void Start()
    {
        SetUpTutorial();
    }

    private void SetUpTutorial()
    {
        cnvsTutorial.SetActive(true);
        index = 0;
        NextTutorial();
    }

    private void NextTutorial()
    {
        if (index < datatutorial.Data.Length)
        {
            txttutorial.SetText(datatutorial.Data[index].ContentTutor);

            if (datatutorial.Data[index].PictureTutor != null)
            {
                imgTutorial.sprite = datatutorial.Data[index].PictureTutor;
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
