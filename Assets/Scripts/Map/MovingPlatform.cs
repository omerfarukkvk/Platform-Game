using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startPoint;
    public Transform[] pos;

    private int i;
    void Start()
    {
        transform.position = pos[startPoint].position;        
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, pos[i].position) < 0.02f)
        {
            i++;
            if (i == pos.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, pos[i].position, speed * Time.deltaTime);
    }
}
