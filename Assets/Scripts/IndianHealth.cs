using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianHealth : MonoBehaviour
{
    private HealthManager indianBar;
    public static float playerHitPoints;
    public float playerMaxHitPoints;
    public static bool colliding;
    public static bool gameOver;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);

        indianBar = GameObject.Find("Main UI").GetComponent<HealthManager>();

        playerHitPoints = playerMaxHitPoints;
        indianBar.setHealth(playerHitPoints, playerMaxHitPoints);
        gameOver = false;
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
            playerHitPoints--;

            if(!Enemy.isDead)
            {
                Invoke("isTouching", 1f);
            }
            
            indianBar.setHealth(playerHitPoints, playerMaxHitPoints);
            if (0 >= playerHitPoints)
                gameOver = true;
        }
    }

    private void isTouching()
    {
        playerHitPoints--;
        indianBar.setHealth(playerHitPoints, playerMaxHitPoints);
    }
}
