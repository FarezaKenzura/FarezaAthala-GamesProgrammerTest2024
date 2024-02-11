using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jono : BaseCharacter
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            BaseEnemy enemyCharacter = other.gameObject.GetComponent<BaseEnemy>();
            if (enemyCharacter != null)
            {
                Debug.Log("Player menyerang musuh!");
                enemyCharacter.TakeDamage(CurrentAttack, 0);
            }
        }
    }
}
