using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuki : BaseCharacter
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            BaseEnemy enemyCharacter = other.gameObject.GetComponent<BaseEnemy>();
            if (enemyCharacter != null)
            {
                Debug.Log("Player menyerang musuh!");
                enemyCharacter.TakeDamage(0, CurrentAttack);
            }
        }
    }
}
