using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grende : MonoBehaviour
{
    public float speed;
    public float life;
    public Text distance;
    Transform player;
    Vector2 dir;
    private bool canTeleport;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dir = Vector2.zero;
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
        if (Vector2.Distance(transform.position, player.position) < 10)
        {
            dir = player.GetComponent<Rigidbody2D>().velocity.normalized;
            transform.Translate(dir * speed * Time.deltaTime);
        }
        distance.text = Vector2.Distance(player.transform.position, transform.position).ToString();
    }
}
