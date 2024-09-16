using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.SceneManagement;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform obstacleSpawnPoint;
    public float initialSpawnInterval = 5f;
    public float spawnIntervalDecreaseRate = 0.1f;
    public float minimumSpawnInterval = 0.5f;

    public TMP_Text BossMoney;
    int Money = 300;

    public static int PuchedPlayer = 0;

    private float currentSpawnInterval;
    private float timeSinceLastSpawn;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        timeSinceLastSpawn = 0f;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= currentSpawnInterval)
        {
            SpawnObstacle();

            timeSinceLastSpawn = 0f;

            currentSpawnInterval -= spawnIntervalDecreaseRate;

            if (currentSpawnInterval < minimumSpawnInterval)
            {
                currentSpawnInterval = minimumSpawnInterval;
            }
        }
        if (Money == 0)
        {
            SceneManager.LoadScene("GoodEnding");
        }
        if (PuchedPlayer == 10)
        {
            SceneManager.LoadScene("SecretEnding");
        }
    }

    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedObstacle = obstaclePrefabs[randomIndex];

        Instantiate(selectedObstacle, obstacleSpawnPoint.position, obstacleSpawnPoint.rotation);
        Money -= 5;
        BossMoney.text = ($"Boss Money: {Money}$");
    }
    public static void BadEnd ()
    {
        SceneManager.LoadScene("BadEnding");
    }

}
