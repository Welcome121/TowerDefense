using UnityEngine;
using TMPro;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreFab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 15f;

    public TextMeshProUGUI waveCountDownText;
    public TextMeshProUGUI waveLevelText;

    private float countDown = 3f;
    private int waveNumber = 1;

    void Update()
    {
        if(countDown <= 0f) {
            waveLevelText.text = "Wave Level: " + waveNumber;
            SpawnWave();
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        waveCountDownText.text = "Time next wave: " + Mathf.Floor(countDown).ToString();
    }
    void SpawnWave() 
    {
        for(int i = 0; i < waveNumber; i++) {
            SpawnEnemy();
        }
        waveNumber++;
    }
    void SpawnEnemy() { Instantiate(enemyPreFab, spawnPoint.position, spawnPoint.rotation); }
}
