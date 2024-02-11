using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject youWinPanel;

    public void DestroyEnemy(BaseEnemy enemy)
    {
        Destroy(enemy.gameObject); 

        if (!AreAnyEnemiesLeft())
        {
            StartCoroutine(DelayedWinPanelActivation());
        }
    }

    private IEnumerator DelayedWinPanelActivation()
    {
        yield return new WaitForSeconds(1f);
        
        youWinPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public bool AreAnyEnemiesLeft()
    {
        BaseEnemy[] enemies = FindObjectsOfType<BaseEnemy>();
        return enemies.Length > 1;
    }

    public void InitializeEnemy(OverlayTile tile)
    {
        GameObject enemyGameObject = Instantiate(enemyPrefab, tile.transform.position, Quaternion.identity);
        enemyGameObject.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z - 1);
    }
}
