using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public abstract class BaseEnemy : MonoBehaviour
{
    public EnemyData enemyData;

    protected int CurrentHP { get; private set; }
    protected int CurrentAttack { get; private set; }
    protected int CurrentDefense { get; private set; }
    protected int CurrentResistance { get; private set; }

    public OverlayTile standingOnTile;

    public GameObject popUpPrefabs;
    public TMP_Text damageText;

    private EnemyManager enemyManager;

    protected virtual void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        InitializeStats();
    }

    protected virtual void InitializeStats()
    {
        CurrentHP = enemyData.hpStats;
        CurrentAttack = enemyData.atkStats;
        CurrentDefense = enemyData.defStats;
        CurrentResistance = enemyData.resStats;
    }

    public virtual void TakeDamage(int physicalDamage, int magicalDamage)
    {
        int totalPhysicalDamage = Mathf.Max(0, physicalDamage - CurrentDefense);
        int totalMagicalDamage = Mathf.Max(0, magicalDamage - CurrentResistance);

        CurrentHP -= totalPhysicalDamage;
        CurrentHP -= totalMagicalDamage;

        if (totalPhysicalDamage > 0)
        {
            damageText.text = totalPhysicalDamage.ToString();
            Instantiate(popUpPrefabs, transform.position, Quaternion.identity);
        }

        if (totalMagicalDamage > 0)
        {
            damageText.text = totalMagicalDamage.ToString();
            Instantiate(popUpPrefabs, transform.position, Quaternion.identity);
        }

        if (CurrentHP <= 0)
        {
            enemyManager.DestroyEnemy(this);
        }
    }
}
