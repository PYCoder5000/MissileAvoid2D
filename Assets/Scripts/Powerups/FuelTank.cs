using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
    [Header("Player")]
    public Transform player;
    [Header("Controls")]
    public float chargingDistance;
    public float chargingSpeed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < chargingDistance)
        {
            player.GetComponent<PlayerMovement>().AddFuel(chargingSpeed * Time.deltaTime);
        }
    }
}
