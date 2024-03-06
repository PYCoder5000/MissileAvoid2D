using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float startHealth;
    //Privates
    float currentHealth;
    PlayerMovement playerM;
    private void Start()
    {
        currentHealth = startHealth;
        playerM = GetComponent<PlayerMovement>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
    public void HealHealth(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > startHealth)
        {
            currentHealth = startHealth;
        }
    }
    public float getHealth()
    {
        return currentHealth;
    }
    public bool isDeath()
    {
        return currentHealth <= 0;
    }
    public void Restart()
    {
        currentHealth = startHealth;
        playerM.enabled = true;
        playerM.Restart();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool destroy = false;
        if (collision.CompareTag("Health"))
        {
            HealHealth(25);
            destroy = true;
        }
        else if (collision.CompareTag("G")){
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<MissileSpawner>().Delete();
            destroy = true;
        }
        if (destroy)
        {
            Destroy(collision.gameObject);
        }

    }
}
