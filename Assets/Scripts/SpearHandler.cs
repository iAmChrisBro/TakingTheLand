using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpearHandler : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;

    public TMP_Text arrowCounter;
    private int aCounter;
    private bool reload;

    public AudioSource src;
    public AudioClip[] clips;

    private void Start()
    {
        points = new GameObject[numOfPoints];
        aCounter = 5;
        arrowCounter.text = aCounter.ToString();

        src.clip = clips[0];

        /*for (int i = 0; i < numOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }*/
    }

    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0) && !reload)
            Shoot();

        if (Input.GetKeyUp(KeyCode.R))
        {
            arrowCounter.text = "Reloading";
            Invoke("Reload", 2);
        }

        /*for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }*/

    }

    private void Reload()
    {
        aCounter = 5;
        arrowCounter.text = aCounter.ToString();
        reload = false;
    }

    void Shoot()
    {


        if (aCounter == 0)
        {
            arrowCounter.text = "RELOAD [R]";
            reload = true;
        }
        else
        {
            if (IndianHealth.gameOver)
                arrowCounter.text = aCounter.ToString();
            else
            {
                src.Play();
                aCounter--;
                arrowCounter.text = aCounter.ToString();
                GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
                newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }
        }
    }
}
