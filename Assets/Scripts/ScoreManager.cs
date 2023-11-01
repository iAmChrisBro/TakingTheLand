using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text highScore;

    void Update()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (Generator.waves > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Generator.waves);
            PlayerPrefs.Save();
        }
        highScore.text = $"{PlayerPrefs.GetInt("HighScore")}";
    }

}
