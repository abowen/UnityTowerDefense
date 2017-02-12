using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform EnemyPrefab;
    public Transform SpawnPoint;
    public float TimeBetweenWaves = 5.5f;
    public Text WaveCountdownText;

    private float countdown = 2f;
    private int waveNumber = 0;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWaves());
            countdown = TimeBetweenWaves;
        }

        WaveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWaves()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log("Wave incoming: " + waveNumber);
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
