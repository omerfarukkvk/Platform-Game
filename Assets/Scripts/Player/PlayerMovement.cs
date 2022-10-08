using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject fireP;
    private Rigidbody2D rb;
    private Animator anim;
    public RuntimeAnimatorController animWGun;
    public bool grounded;
    public bool jumpCooldown;
    public bool wGun;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
            fireP.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            fireP.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.W) && grounded && jumpCooldown)
            Jump();

        if (wGun)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = animWGun;
            
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed * 2.5f);
        grounded = false;
        StartCoroutine(JumpCooldown());
    }

    IEnumerator JumpCooldown()
    {
        jumpCooldown = false;
        yield return new WaitForSeconds(0.4f);
        jumpCooldown = true;
    }
}
