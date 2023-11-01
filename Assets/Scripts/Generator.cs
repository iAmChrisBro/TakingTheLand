using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    public float timer;
    public float multiplier;
    public GameObject enemy;
    public int EnemyCount;
    public static int EnemyLeft;
    private int OGEnemyCount;
    public static int waves;
    public TMP_Text waveCount, enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 5;
        EnemyLeft = EnemyCount;
        waves = 1;
        OGEnemyCount = EnemyCount;
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (EnemyLeft == 0)
        {
            WaveUpdate();
        }

        enemyCount.text = EnemyLeft.ToString();
    }

    IEnumerator EnemySpawn()
    {
        while (EnemyCount > 0)
        {
            EnemyCount--;
            Vector3 position = new Vector3(transform.position.x, transform.position.y);
            GameObject tempEnemy = Instantiate(enemy, position, Quaternion.identity);
            timer = Random.Range(1f, 3f);
            yield return new WaitForSeconds(timer);
        }
    }

    private void WaveUpdate()
    {
        waves++;
        OGEnemyCount += 2;
        EnemyCount = OGEnemyCount;
        EnemyLeft = EnemyCount;
        waveCount.text = waves.ToString();
        timer -= multiplier;
        StartCoroutine(EnemySpawn());
    }
    
}
