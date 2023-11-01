using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public TMP_Text skipText;
    private bool check;

    void Start()
    {
        skipText.text = "";
        check = false;
        Invoke("showText", 3);
        Invoke("loadLevel", 16);
    }
   
    void Update()
    {
        if(check)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                loadLevel();
            }
        }
    }

    void showText()
    {
        skipText.text = "[space to skip]";
        check = true;
    }

    void loadLevel()
    {
        SceneManager.LoadScene(3);
    }
}
