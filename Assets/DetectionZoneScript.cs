using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>(); ;
            Vector2 direction = player.playerRigidbody2D.position - new Vector2(transform.position.x, transform.position.y);
            enemy.Move(direction.normalized, 10f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.StopMove();
        }
    }
}
