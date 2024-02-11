using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [Header("Current Stats")]
    public CharactersData characterData;
    protected int CurrentHP { get; private set; }
    protected int CurrentAttack { get; private set; }
    protected int CurrentDefense { get; private set; }
    protected int CurrentResistance { get; private set; }

    public OverlayTile standingOnTile;

    //[Header("Pop Up Damage")]
    //public GameObject popUpPrefabs;
    //public TMP_Text damageText;

    protected virtual void Start()
    {
        InitializeStats();
    }

    protected virtual void InitializeStats()
    {
        CurrentHP = characterData.hpStats;
        CurrentAttack = characterData.atkStats;
        CurrentDefense = characterData.defStats;
        CurrentResistance = characterData.resStats;
    }

    public virtual void TakeDamage(int physicalDamage, int magicalDamage)
    {
        int totalPhysicalDamage = Mathf.Max(0, physicalDamage - CurrentDefense);
        int totalMagicalDamage = Mathf.Max(0, magicalDamage - CurrentResistance);

        CurrentHP -= totalPhysicalDamage;
        CurrentHP -= totalMagicalDamage;

        /*if (totalPhysicalDamage > 0)
        {
            damageText.text = totalPhysicalDamage.ToString();
            Instantiate(popUpPrefabs, transform.position, Quaternion.identity);
        }

        if (totalMagicalDamage > 0)
        {
            damageText.text = totalMagicalDamage.ToString();
            Instantiate(popUpPrefabs, transform.position, Quaternion.identity);
        }*/

        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
