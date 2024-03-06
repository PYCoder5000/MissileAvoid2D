using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrende : MonoBehaviour
{
    public GameObject grende;
    private void Update()
    {
        if (transform.childCount == 1)
        {
            GameObject g = Instantiate(grende, transform);
            g.transform.position = GenerateRandomPosition();
            g.SetActive(true);
        }
    }
    Vector2 GenerateRandomPosition()
    {
        Vector2 randomPos = new Vector2(Random.Range(-41.5f, 41.5f), Random.Range(-16.5f, 16.5f));
        return randomPos;
    }
}
