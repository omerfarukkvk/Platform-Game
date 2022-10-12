using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHeart;
    private bool isTouching;
    private bool isTouchable = true;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health > numOfHeart)
        {
            health = numOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
        if (isTouching && isTouchable)
        {
            health--;
            StartCoroutine(Immunity());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bee" && isTouchable)
        {
            isTouching = true;
            health--;
            StartCoroutine(Immunity());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bee")
        {
            isTouching = false;
        }
    }

    IEnumerator Immunity()
    {
        isTouchable = false;
        yield return new WaitForSeconds(1f);
        isTouchable = true;
    }
}
