using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public ParticleSystem hitGround;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(hitGround, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bee")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy>().health -= 30;
        }
    }
}
