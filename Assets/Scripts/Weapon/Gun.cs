using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject fireSprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponent<PlayerMovement>().wGun)
        {
            Shoot();
            StartCoroutine(FireSpriteOn());
        }
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator FireSpriteOn()
    {
        fireSprite.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fireSprite.SetActive(false);
    }
}
