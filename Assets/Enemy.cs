using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject healthTextGameObject;
    public PlayerController player;
    Canvas canvas;
    public Animator enemyAnimator;
    public Rigidbody2D enemyRigidbody2D;
    public Collider2D enemyCollider2D;
    public float _health = 10;
    public float score = 0;
    TextMeshProUGUI scoreText;
    public float Health
    {
        set
        {
            if (_health > value)
            {
                enemyAnimator.SetTrigger("hit");
                GameObject healthText = Instantiate(healthTextGameObject);
                RectTransform textTransform = healthText.GetComponent<RectTransform>();
                TextMeshProUGUI textMeshPro = healthText.GetComponent<TextMeshProUGUI>();
                textMeshPro.text = (_health - value).ToString();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                textTransform.SetParent(canvas.transform);
                player.score += (_health - value);
                scoreText.text = "Score: " + player.score.ToString();
            }
            _health = value;
            if (_health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return _health;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Player")
        {
            Vector2 Knockback = new Vector2(transform.position.x, transform.position.y) - collision.GetContact(0).point;
            Knockback = Knockback.normalized;
            enemyRigidbody2D.AddForce(Knockback * 10, ForceMode2D.Impulse);
            Health -= 1;
        }
    }
    public void Move(Vector2 direction, float speed)
    {
        enemyAnimator.SetBool("isMoving", true);
        enemyRigidbody2D.AddForce(direction * speed);
    }
    public void StopMove()
    {
        enemyAnimator.SetBool("isMoving", false);
    }
    public void OnHitKnockback(Vector2 vector2, float magnitude)
    {
       enemyRigidbody2D.AddForce((new Vector2(transform.position.x, transform.position.y) - vector2) * magnitude, ForceMode2D.Impulse);
    }
    public void Defeated()
    {
        enemyAnimator.SetTrigger("death");
    }
    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
