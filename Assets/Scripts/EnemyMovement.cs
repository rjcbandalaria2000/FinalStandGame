using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D enemyRB;
    public GameObject player;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            WalkToPlayer();
        }
        else
        {
            return;
        }
       
    }

    void WalkToPlayer()
    {
        
        Vector3 direction = player.transform.position - enemyRB.transform.position;
        direction.Normalize();
        //Debug.Log(direction);
        movement = direction;

        enemyRB.MovePosition(transform.position + direction * speed * Time.deltaTime);


    }

    void WalkRight()
    {
        movement.x = 1;
        enemyRB.MovePosition(enemyRB.position + movement * speed * Time.deltaTime);
    }
    
    void WalkLeft()
    {
        movement.x = -1;
        //this.transform.
        enemyRB.MovePosition(enemyRB.position + movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.takeDamage(1);
            Destroy(gameObject);
        }
    }

 }
