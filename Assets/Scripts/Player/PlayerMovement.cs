using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration;
    public float breakPower;
    [Header("Controls")]
    public float startFuel;
    public float efficency;
    //Privates
    float timeSurvived = 0f;
    float fuel;
    Rigidbody2D rb;
    private bool canTeleport;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuel = startFuel;
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * acceleration;
        float vertical = Input.GetAxisRaw("Vertical") * acceleration;
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
        if (fuel <= 0)
        {
            horizontal = 0;
            vertical = 0;
        }
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            fuel -= efficency * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.drag = breakPower;
        }
        else
        {
            rb.drag = 0;
        }
        if (rb.velocity.magnitude > 0){
            rb.AddForce(new Vector2(horizontal * Time.deltaTime, vertical * Time.deltaTime));
        }
        timeSurvived += Time.deltaTime;
    }
    public void AddFuel(float amount)
    {
        fuel += amount;
        if (fuel > startFuel)
        {
            fuel = startFuel;
        }
    }
    public float getFuel()
    {
        return fuel;
    }
    public float getTime()
    {
        return timeSurvived;
    }
    public float getSpeed()
    {
        return rb.velocity.magnitude;
    }
    public void Restart()
    {
        timeSurvived = 0;
        fuel = startFuel;
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;
    }
}
