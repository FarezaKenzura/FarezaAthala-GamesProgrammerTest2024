using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Scriptable Objects/Character Data")]
public class CharactersData : ScriptableObject
{
    [Header("Informations")]
    public string nameChar;
    public enum Character{ Infantry, Cavalry, Flier }
    public Character typeChar;
    public Sprite artWorkChar;

    [Header("Statistics")]
    public int hpStats;
    public int atkStats;
    public int defStats;
    public int resStats;
    
    [Header("Models")]
    public GameObject characterPrefab;
}
