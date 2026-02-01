using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private float enemyInterval = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, EnemyPrefab));

    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(enemyInterval);
        GameObject newwEnemy =Instantiate(enemy, new Vector3(Random.Range(-2f,2),Random.Range(-3f,3f),0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
