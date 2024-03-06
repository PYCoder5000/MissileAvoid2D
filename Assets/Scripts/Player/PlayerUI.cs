using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("UI")]
    public Slider healthbar;
    public Slider fuelbar;
    public GameObject gameOver;
    public Text timeSurvivedText;
    public Text speed;
    //Privates
    Player player;
    PlayerMovement playerM;
    private void Start()
    {
        player = GetComponent<Player>();
        playerM = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        healthbar.value = player.getHealth() / player.startHealth;
        fuelbar.value = playerM.getFuel() / playerM.startFuel;
        if (player.isDeath())
        {
            gameOver.SetActive(true);
            playerM.enabled = false;
            timeSurvivedText.text = Mathf.RoundToInt(playerM.getTime()).ToString() + " seconds";
        }
        speed.text = ((decimal)playerM.getSpeed()).ToString("#.##") + " m/s";
    }
}
