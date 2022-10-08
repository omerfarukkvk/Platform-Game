using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public ParticleSystem deadthParticle;
    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            destroyEnemy();
        }
    }

    void destroyEnemy()
    {
        Instantiate(deadthParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
