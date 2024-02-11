using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Scriptable Objects/Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("Informations")]
    public string nameEnemy;
    public Sprite artWorkEnemy;
    
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
    public GameObject enemyPrefab;
}
