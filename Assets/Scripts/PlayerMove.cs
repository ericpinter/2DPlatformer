using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;
    Animator animator;

    bool jumping;

    float horizontal;

    public float runSpeed = 5f;
    public float jumpForce = 400f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal < 0)
		{
            this.gameObject.transform.localScale = new Vector3(-0.6f, 0.6f, 1);
		}
		else if(horizontal > 0)
		{
            this.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 1);
		}

        if(Input.GetKeyDown("space") && !jumping)
		{
            body.AddForce(new Vector2(0, jumpForce));
            jumping = true;
            AudioManagerScript.PlaySound("Jump");
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
