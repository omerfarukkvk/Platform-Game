using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    public bool grounded;

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
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.W) && grounded)
            Jump();

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed * 2.5f);
        grounded = false;
    }
}
