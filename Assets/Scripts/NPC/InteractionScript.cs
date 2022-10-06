using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public bool control;
    public PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && control)
            if (gameObject.tag == "Gun")
            {
                player.wGun = true;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "NPC")
            {

            }    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control = false;
        }
    }
}
