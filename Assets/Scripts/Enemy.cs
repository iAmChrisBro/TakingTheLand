using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthManager healthBar;
    private HealthManager indianBar;
    private float HitPoints;
    public float MaxHitPoints;
    public static bool isDead;

    private Transform target;
    public float speed;
    public float min,max;

    // Start is called before the first frame update
    void Start()
    {

        HitPoints = MaxHitPoints;
        healthBar.setHealth(HitPoints, MaxHitPoints);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = Random.Range(min,max);

        isDead = false;

    }
        
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            HitPoints -= 1;
            healthBar.setHealth(HitPoints, MaxHitPoints);
            if (0 >= HitPoints)
            {
                Generator.EnemyLeft--;
                Destroy(this.gameObject);
                isDead = true;
            }
        }

        if (col.gameObject.tag == "Tomahawk")
        {
            HitPoints -= 2;
            
            healthBar.setHealth(HitPoints, MaxHitPoints);
            if (0 >= HitPoints)
            {
                Generator.EnemyLeft--;
                Destroy(this.gameObject);
                isDead = true;
            }
        }

        if (col.gameObject.tag == "Spear")
        {
            HitPoints -= MaxHitPoints;
            
            healthBar.setHealth(HitPoints, MaxHitPoints);
            if (0 >= HitPoints)
            {
                Generator.EnemyLeft--;
                Destroy(this.gameObject);
                isDead = true;
            }
        }

    }
}
