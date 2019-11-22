using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 3f;
    private float countdown = 2f;
    public float spawnSpeed = 0.5f;
    public Text waveCountdownText;

    public int waveIndex = 10;

    void Start()
    {
        StartCoroutine("SpawnWave");    
    }
    void Update()
    {
        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }
    IEnumerator SpawnWave() {
      
        while (waveIndex>0)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnSpeed);
        }
    }
    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        
    }

}
