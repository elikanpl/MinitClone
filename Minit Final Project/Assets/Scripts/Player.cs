using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Player : ResetableObject
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float climbSpeed;
    private float normalSpeed;
    public string direction;
    public bool sleep;
    public int lives;

    public Sprite death;

    private bool isFacingRight = true;
    public bool isDead;

    SpriteRenderer spriteRenderer;
    Collider2D playerCollider;
    public Animator animator;

    public float bounceSpeed;
    private Vector3 bounce;
    private bool bouncing;

    public Sprite standing;
    public Sprite standingWithSword;
    public Sprite climbStill;
    private Sprite stillSprite;

    public AudioSource deathSound;
    public AudioSource hurtSound;

    public RuntimeAnimatorController withSword;
    public RuntimeAnimatorController climbing;

    private LayerMask noExclusions;
    void Start()
    {
        sleep = false;
        isDead = false;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        playerCollider = this.GetComponent<Collider2D>();
        ResetManager.addTo(this);
        lives = 2;
        hurtSound = GetComponent<AudioSource>();
        noExclusions = playerCollider.excludeLayers;
        stillSprite = standing;
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

            if ((Inventory.reference.sword && Input.GetKeyDown(KeyCode.C)) || lives <= 0)
            {
                TextManager.reference.DisplayDeath("You died!");
                Die();
            }
            
            this.transform.position += vel * Time.deltaTime;
        }
        if (!isDead)
        {
            if (vel == new Vector3(0, 0, 0))
            {
                animator.enabled = false;
                spriteRenderer.sprite = stillSprite;
            }
            else
            {
                animator.enabled = true;
            }
        }

        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetManager.reference.ResetRun();
            }
        }

        // Bounce the player back when hit by an enemy
        if(bouncing)
        {
            this.transform.position += bounce * Time.deltaTime;
        }

    }

    public override void Reset()
    {
        base.Reset();
        lives = 2;
        playerCollider.excludeLayers = noExclusions;
        animator.enabled = true;
        sleep = false;
        TextManager.reference.HideDeath();
        TextManager.reference.HideControls();
        // Slight delay to prevent sword being triggered from X input
        Invoke("Live", 0.1f);
    }

    public void Die()
    {
        if(deathSound != null) deathSound.Play();
        TextManager.reference.DisplayControls("Press Space to Continue");
        CancelInvoke();
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
    public void GetHit(GameObject enemy)
    {
        if(hurtSound != null) hurtSound.Play();
        sleep = true;
        // Direction to bounce the player back
        bounce = this.transform.position - enemy.transform.position;
        bounce = bounce.normalized;
        bounce *= bounceSpeed;
        bouncing = true;
        // Invincibility frames
        InvokeRepeating("Flicker", 0.1f, 0.1f);
        //playerCollider.enabled = false;
        playerCollider.excludeLayers = LayerMask.GetMask("Enemy");
        Invoke("IFramesEnd", 1.2f);
        if(lives > 1)
        {
            Invoke("BounceEnd", 0.05f);
        }
        else
        {
            Invoke("BounceEnd", 0.4f);
        }
        lives--;

    }

    private void IFramesEnd()
    {
        //playerCollider.enabled = true;
        playerCollider.excludeLayers = noExclusions;
        spriteRenderer.enabled = true;
        CancelInvoke();
    }

    // Flicker the sprite when damaged
    private void Flicker()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
    private void BounceEnd()
    {
        sleep = false;
        bouncing = false;
        if (lives == 0)
        {
            // Stop flickering
            CancelInvoke();
            spriteRenderer.enabled = true;
        }
    }

    // Climb the lighthouse ladder
    public void Climb()
    {
        animator.runtimeAnimatorController = climbing;
        stillSprite = climbStill;
        normalSpeed = moveSpeed;
        moveSpeed = climbSpeed;
    }

    // Stop climbing the lighthouse ladder
    public void StopClimb()
    {
        animator.runtimeAnimatorController = withSword;
        stillSprite = standingWithSword;
        moveSpeed = normalSpeed;
    }

    public void EquipSword()
    {
        animator.runtimeAnimatorController = withSword;
        stillSprite = standingWithSword;
    }

    public void UnequipSword()
    {
        stillSprite = standing;
    }
}
