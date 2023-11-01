using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SetIntro());
    }

    IEnumerator SetIntro()
    {
        yield return new WaitForSeconds(3.1f);
        SceneManager.LoadScene(1);
    }
}
