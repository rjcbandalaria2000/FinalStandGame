using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    //public static SpawnEnemies instance;
    public GameObject player;
    public GameObject enemy;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

   
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        GameObject e = Instantiate(enemy) as GameObject;
        GameObject e2 = Instantiate(enemy) as GameObject;
        e.transform.position = new Vector2(-screenBounds.x - 5, 0);
        e2.transform.position = new Vector2(screenBounds.x + 5, 0);
        
    }

    IEnumerator enemyWave()
    {
        while (player!= null)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();

            if(player == null)
            {
               yield return false;
            }

        }
        
    }
    
    public void StopSpawn()
    {
        StopCoroutine(enemyWave());
    }
}
