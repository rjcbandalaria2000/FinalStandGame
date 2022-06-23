using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int bulletSpeed;
    public float bulletDuration = 0.8f;
    public Rigidbody2D bulletRB;
    public int bulletDamage = 1;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bulletRB = this.GetComponent<Rigidbody2D>();
       // Invoke("AutoDestroy", bulletDuration);
        
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x > screenBounds.x +5 || this.transform.position.x < -screenBounds.x - 5)
        {
            Destroy(gameObject);
        }
    }
    public void travelLeft()
    {
        bulletRB.velocity = -transform.right * bulletSpeed;
    }
    public void travelRight()
    {

        bulletRB.velocity = transform.right * bulletSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.takeDamage(bulletDamage);
            Destroy(gameObject);
            //Destroy(collision.gameObject);
            
        }
    }
}
