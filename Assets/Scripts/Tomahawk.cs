using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomahawk : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    private AudioSource src;
    private GameObject indian;


    void Start()
    {
        src = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        indian = GameObject.Find("Indian");
        Physics2D.IgnoreCollision(indian.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void Update()
    {
        if (!hasHit)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            hasHit = true;
            Destroy(this.gameObject);
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        if (col.gameObject.tag == "Ground")
        {
            src.Play();
        }

        Destroy(this.gameObject);

    }
}
