using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    public CharactersData characterData;

    // Current stats during battle
    protected int CurrentHP { get; private set; }
    protected int CurrentAttack { get; private set; }
    protected int CurrentDefense { get; private set; }
    protected int CurrentResistance { get; private set; }

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

    public abstract void Attack();
    public abstract void Wait();

    public virtual void TakeDamage(int physicalDamage, int magicalDamage)
    {
        // Calculate damage based on defense and resistance
        int totalPhysicalDamage = Mathf.Max(0, physicalDamage - CurrentDefense);
        int totalMagicalDamage = Mathf.Max(0, magicalDamage - CurrentResistance);

        // Apply damage to character
        CurrentHP -= totalPhysicalDamage;
        CurrentHP -= totalMagicalDamage;

        // Check if the character is defeated
        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
