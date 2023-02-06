using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float playerMoveSpeed;
    public float _health;
    public float _score = 0;
    public float score
    {
        set
        {
            if (playerCollider2D.enabled == true)
                _score = value;
        }
        get
        {
            return _score;
        }
    }
    public float Health
    {
        set
        {
            _health = value;
            if (_health <= 0)
            {
                playerDie();
            }
        }
        get
        {
            return _health;
        }
    }
    public SwordAttack playerSwordAttack;
    Vector2 movementInput;
    public Rigidbody2D playerRigidbody2D;
    public Animator playerAnimator;
    public SpriteRenderer playerSpriteRenderer;
    public Collider2D playerCollider2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!canMove || movementInput == Vector2.zero)
        {
            playerAnimator.SetBool("isMoving", false);
            return;
        }

        if (movementInput.x < 0)
            playerSpriteRenderer.flipX = true;
        else if (movementInput.x > 0)
            playerSpriteRenderer.flipX = false;

        playerAnimator.SetBool("isMoving", true);
        //rb.velocity = movementInput * moveSpeed;
        playerRigidbody2D.AddForce(movementInput * playerMoveSpeed);
    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    void OnFire()
    {
        playerAnimator.SetTrigger("swordAttack");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy") // take damage from enemy
        {
            Vector2 Knockback = new Vector2(transform.position.x, transform.position.y) - collision.GetContact(0).point;
            Knockback = Knockback.normalized;
            playerRigidbody2D.AddForce(Knockback * 10, ForceMode2D.Impulse);
            Health -= 1;
        }
    }
    public void SwordAttack()
    {
        LockMovement();
        if (playerSpriteRenderer.flipX == true)
        {
            playerSwordAttack.AttackLeft();
        }
        else
        {
            playerSwordAttack.AttackRight();
        }
    }
    public void StopSwordAttack()
    {
        UnlockMovement();
        playerSwordAttack.StopAttack(); 
    }
    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }
    public void playerDie()
    {
        playerAnimator.SetBool("isAlive", false);
        LockMovement();
        playerCollider2D.enabled = false;
    }
}
