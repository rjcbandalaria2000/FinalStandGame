using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;
    public GameObject player;
    public GameObject enemySpawner;
    //public GameObject[] enemy;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
     
    }

    // Update is called once per frame
    void Update()
    {
       if(player == null)
       {
            //GameOver();
            StartCoroutine(GameOver());
       }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        ScoreSystem.instance.SetHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void enemyHealthIncrease()
    {
        
    }

    
}
