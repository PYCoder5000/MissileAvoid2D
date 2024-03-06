using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public Transform player;
    public float time;
    public Transform[] missiles;
    public Vector2[] propPositions;
    public bool noSpawn;
    public int numMissiles;
    float passedTime;
    private void Update()
    {
        if (noSpawn)
        {
            passedTime -= Time.deltaTime;
        }
        if (passedTime >= time)
        {
            passedTime = 0;
            createMissiles();
        }
        passedTime += Time.deltaTime;
    }
    void createMissiles()
    {
        if (numMissiles > 100)
        {
            return;
        }
        foreach (Transform trans in missiles)
        {
            if (trans == null)
            {
                continue;
            }
            if (trans.CompareTag("Missile"))
            {
                numMissiles += 4;
                for (int i = 0; i < 4; i++)
                {
                    Vector2 pos = GenerateRandomPosition();
                    GameObject missileIns = Instantiate(trans, transform).gameObject;
                    missileIns.transform.position = pos;
                    missileIns.SetActive(true);
                    missileIns.GetComponent<Missile>().SetPropPosition(propPositions[0]);
                }
            }
            if (trans.CompareTag("Nuke"))
            {
                Vector2 pos = GenerateRandomPosition();
                GameObject missileIns = Instantiate(trans, transform).gameObject;
                missileIns.transform.position = pos;
                missileIns.SetActive(true);
                missileIns.GetComponent<Missile>().SetPropPosition(propPositions[1]);
            }
        }
    }
    Vector2 GenerateRandomPosition()
    {
        Vector2 randomPos = new Vector2(Random.Range(-9.45f, 9.45f), Random.Range(-3.75f, 3.75f));
        return randomPos;
    }
    public void Delete()
    {
        List<GameObject> missiles = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject missile = transform.GetChild(i).gameObject;
            if (missile.activeSelf == true && missile.tag != "Respawn")
            {
                missiles.Add(missile);
            }
        }
        foreach (GameObject m in missiles)
        {
            GameObject explosionGO = Instantiate(m.GetComponent<Missile>().explosion, m.GetComponent<Missile>().particleParent.transform);
            explosionGO.transform.position = m.transform.position;
            Destroy(m);
        }
        numMissiles -= 1;
    }
}
