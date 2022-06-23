using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHP;
    bool isDead = false;
    public int points = 100;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnemyDead())
        {

        }
        else if (isEnemyDead())
        {
            ScoreSystem.instance.AddScore(points);
            Destroy(gameObject);
            AudioSystem.instance.PlaySound(AudioEnum.SFX_EnemyDeath);
        }
    }

    public void takeDamage(int damage)
    {

        enemyHP -= damage;

    }

    bool isEnemyDead()
    {
        if(enemyHP <= 0)
        {
            return isDead = true;
        }
        else
        {
            return isDead = false; 
        }
    }

    public int GetEnemyHealth()
    {
        return enemyHP;
    }

    public int GetEnemyPoints()
    {
        return points;
    }

    public void SetEnemyHealth(int health)
    {
        enemyHP = health;
    }

    public void IncreaseEnemyHealth(int health)
    {
        enemyHP += health;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        ScoreSystem.instance.SetHighScore();
    //        GetComponent<SpawnEnemies>().StopSpawn();
    //        Destroy(gameObject);
    //        Destroy(collision.gameObject);
    //    }
    //}
}
