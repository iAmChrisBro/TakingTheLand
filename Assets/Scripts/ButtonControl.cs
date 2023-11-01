using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject bow, tom, spear;
    public GameObject bowText, tomText, spearText;
    public GameObject bowImage, tomImage, spearImage;
    private bool checkTom, checkSpear, checkBow;
    
    void Start()
    {
        tom.SetActive(false);
        spear.SetActive(false);

        tomText.SetActive(false);
        spearText.SetActive(false);

        checkTom = false;
        checkSpear = false;
        checkBow = false;

        bowImage.SetActive(true);
        tomImage.SetActive(false);
        spearImage.SetActive(false);
    }
    void Update()
    {
        if (Generator.waves == 5)
        {
            tom.SetActive(true);
            checkTom = true;
        }

        if (Generator.waves == 10)
        {
            checkSpear = true;
            spear.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1) && checkBow)
        {
            bow.SetActive(false);
            bowText.SetActive(true);
            bowImage.SetActive(true);

            if(Generator.waves >= 2)
            {
                tom.SetActive(true);
                tomText.SetActive(false);
                tomImage.SetActive(false);
            }

            if(Generator.waves >= 3)
            {
                spear.SetActive(true);
                spearText.SetActive(false);
                spearImage.SetActive(false);
            }

        }
        else if(Input.GetKeyUp(KeyCode.Alpha2) && checkTom)
        {
            bow.SetActive(true);
            tom.SetActive(false);

            bowText.SetActive(false);
            tomText.SetActive(true);
          

            bowImage.SetActive(false);
            tomImage.SetActive(true);
           

            if (Generator.waves >= 3)
            {
                spear.SetActive(true);
                spearText.SetActive(false);
                spearImage.SetActive(false);
            }
            checkBow = true;

        }
        else if(Input.GetKeyUp(KeyCode.Alpha3) && checkSpear)
        {
            bow.SetActive(true);
            tom.SetActive(true);
            spear.SetActive(false);

            bowText.SetActive(false);
            tomText.SetActive(false);
            spearText.SetActive(true);

            bowImage.SetActive(false);
            tomImage.SetActive(false);
            spearImage.SetActive(true);
        }
    }

    public void Restart()
    {
        IndianHealth.gameOver = false;
        IndianHealth.playerHitPoints = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void Menu()
    {
        IndianHealth.gameOver = false;
        IndianHealth.playerHitPoints = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        IndianHealth.gameOver = false;
        IndianHealth.playerHitPoints = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
