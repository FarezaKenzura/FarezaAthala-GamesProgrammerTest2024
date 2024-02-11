using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTutorialData", menuName = "Scriptable Objects/Tutorial Data", order = 2)]
public class TutorialData : ScriptableObject
{
    public Tutorial[] Data;
}


[Serializable]
public class Tutorial
{
    [TextArea]
    public string ContentTutor;
    public Sprite PictureTutor;
}