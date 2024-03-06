using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMove : MonoBehaviour
{
    public float speed;
    Vector2 dir;
    Transform player;
    private bool canTeleport;
    private void Start()
    {
        dir = Vector2.zero;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Vector3.Distance(Vector3.zero, transform.position) > 100)
        {
            if (canTeleport)
            {
                transform.position = -transform.position;
                canTeleport = false;
            }
        }
        else
        {
            canTeleport = true;
        }
        if (Vector3.Distance(player.position, transform.position) < 5)
        {
            dir = player.GetComponent<Rigidbody2D>().velocity.normalized;
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
}
