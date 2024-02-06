using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Scriptable Objects/Character Data")]
public class CharactersData : ScriptableObject
{
    [Header("Informations")]
    public string nameChar;
    public Sprite artWorkChar;
    
    public enum MovementType{ Infantry, Cavalry, Flier }
    public MovementType movementType;
    public enum AttackType { Physical, Magical }
    public AttackType attackType;

    
    [Header("Statistics")]
    public int hpStats;
    public int atkStats;
    public int defStats;
    public int resStats;
    
    [Header("Models")]
    public GameObject characterPrefab;
}
