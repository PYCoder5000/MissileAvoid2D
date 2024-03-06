using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;
    public Button restartButton;
    public Button quitButton;
    public GameObject missileSpawner;
    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(quit);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Restart()
    {
        Player playerP = player.GetComponent<Player>();
        playerP.Restart();
        missileSpawner.GetComponent<MissileSpawner>().Delete();
        gameOverScreen.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }
}
