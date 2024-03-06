using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public GameObject healthPack;
    public int startSpawnAmount = 100;
    public float updateSpawnTime = 3;
    float time;
    private void Start()
    {
        for (int i = 0; i < startSpawnAmount; i++)
        {
            GameObject healthpack = Instantiate(healthPack, transform);
            healthpack.transform.position = GenerateRandomPosition();
            healthpack.SetActive(true);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > updateSpawnTime)
        {
            time = 0;
            GameObject healthpack = Instantiate(healthPack, transform);
            healthpack.transform.position = GenerateRandomPosition();
            healthpack.SetActive(true);
        }
    }
    Vector2 GenerateRandomPosition()
    {
        Vector2 randomPos = new Vector2(Random.Range(-41.5f, 41.5f), Random.Range(-16.5f, 16.5f));
        return randomPos;
    }
}
