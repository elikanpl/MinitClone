using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Player : ResetableObject
{
    // Start is called before the first frame update
    public float moveSpeed;
    public string direction;
    public bool sleep;
    public int lives;

    public Sprite death;

    private bool isFacingRight = true;
    public bool isDead;

    SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        sleep = false;
        isDead = false;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        ResetManager.addTo(this);
        lives = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = new Vector3(0, 0, 0);

        if (!sleep)
        {
            if (Input.GetKey(KeyCode.D))
            {
                vel += new Vector3(moveSpeed, 0, 0);
                direction = "right";

                if (isFacingRight == false) {
                    spriteRenderer.flipX = false;
                    isFacingRight = true;
                }

            }
            if (Input.GetKey(KeyCode.A))
            {
                vel += new Vector3(-moveSpeed, 0, 0);
                direction = "left";

                if (isFacingRight == true)
                {
                    spriteRenderer.flipX = true;
                    isFacingRight = false;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                vel += new Vector3(0, moveSpeed, 0);
                direction = "up";

            }
            if (Input.GetKey(KeyCode.S))
            {
                vel += new Vector3(0, -moveSpeed, 0);
                direction = "down";

            }

            if (Input.GetKeyDown(KeyCode.C) || lives <= 0)
            {
                Die();
            }
            this.transform.position += vel * Time.deltaTime;
        }

        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                ResetManager.reference.ResetRun();
            }
        }

    }

    public override void Reset()
    {
        base.Reset();
        lives = 2;
        animator.enabled = true;
        sleep = false;
        // Slight delay to prevent sword being triggered from X input
        Invoke("Live", 0.1f);
    }

    public void Die()
    {
        // Need to write Press X to Continue to screen
        print("Press X to Continue");
        animator.enabled = false;
        spriteRenderer.sprite = death;
        sleep = true;
        isDead = true;
        ResetManager.reference.TimerActive = false;
    }

    private void Live()
    {
        isDead = false;
    }

}
