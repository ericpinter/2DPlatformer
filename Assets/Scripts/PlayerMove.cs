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
    public float jetpackForce = 10f;
    public float jetpackTime = 3f;
    private float jetpackChargeLeft;

    private ParticleSystem jetpackParticles;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jetpackChargeLeft = jetpackTime;
        jetpackParticles = GetComponent<ParticleSystem>();
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
		}
    }

	private void FixedUpdate()
    {
        float jetpackImpulse = 0f;
        if (jumping && Input.GetKey("space") && jetpackChargeLeft > 0f)
        {
            jetpackImpulse = jetpackForce;
            jetpackChargeLeft -= Time.fixedUnscaledDeltaTime;
            body.AddForce(new Vector2 (0,jetpackForce));
            jetpackParticles.Emit(new ParticleSystem.EmitParams(), 5);
            if (!AudioManagerScript.audioSrc.isPlaying) AudioManagerScript.PlaySound("Jump", jetpackTime);
        }
        else
        {
            AudioManagerScript.audioSrc.Stop();
        }

        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);

        if (body.position.y < -100) { GameManager.Instance.GameOver();}
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        jumping = false;
        jetpackChargeLeft = jetpackTime;
    }
}
