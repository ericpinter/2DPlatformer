using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer sr;

    bool jumping;

    float horizontal;

    public float runSpeed = 5f;
    public float jumpForce = 400f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("horizontal", horizontal);

        if(horizontal < 0)
		{
            sr.flipX = false;
		}
		else
		{
            sr.flipX = true;
		}

        if(Input.GetKeyDown("space") && !jumping)
		{
            body.AddForce(new Vector2(0, jumpForce));
            jumping = true;
		}
    }

	private void FixedUpdate()
	{
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        jumping = false;
	}
}
