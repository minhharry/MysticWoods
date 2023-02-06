using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 10;
    Vector3 attackRightOffset;
    public Collider2D swordCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        attackRightOffset = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackRight()
    {
        swordCollider2D.enabled = true;
        transform.localPosition = attackRightOffset;
    }
    public void AttackLeft()
    {
        swordCollider2D.enabled = true;
        transform.localPosition = new Vector3(-attackRightOffset.x, attackRightOffset.y, attackRightOffset.z);
    }
    public void StopAttack()
    {
        swordCollider2D.enabled = false;
        transform.localPosition = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Health -= damage;
            enemy.OnHitKnockback(new Vector2(transform.position.x, transform.position.y), 50);
        }
    }
}
