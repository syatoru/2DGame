using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 400f;
    private bool isGround;
    private int jumpcount = 0;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spRenderer;
       public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(x * speed));
        if(x < 0)
        {
            spRenderer.flipX = true;
        }else if(x > 0)
        {
            spRenderer.flipX = false;
        }
        rb2d.AddForce(Vector2.right * x * speed);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetButtonDown("Jump") & jumpcount < 1)
        {
            anim.SetBool("isJump", true);
            rb2d.AddForce(Vector2.up * jumpForce);
            jumpcount++;
            Debug.Log(jumpcount);
        }
        
        if (isGround)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);
            jumpcount = 0;
        }

        float velX = rb2d.velocity.x;
        float velY = rb2d.velocity.y;

        if (velY > 0.5f)
        {
            anim.SetBool("isJump", true);
        }
        if (velY < -0.1f)
        {
            anim.SetBool("isFall", true);
        }


        if (Mathf.Abs(velX) >10)
        {
            if(velX > 10.0f)
            {
                rb2d.velocity = new Vector2(10.0f, velY);
            }
            if (velX < -10.0f)
            {
                rb2d.velocity = new Vector2(-10.0f, velY);
            }
        }
    }

    private void FixedUpdate()
    {
        isGround = false;
        Vector2 groundPos =
            new Vector2(
                transform.position.x,
                transform.position.y

                );
        Vector2 groundArea = new Vector2(0.5f, 0.5f);
        isGround =
            Physics2D.OverlapArea(
                groundPos + groundArea,
                groundPos - groundArea,
                groundLayer
                );
    }
}
