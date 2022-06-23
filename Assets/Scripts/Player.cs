using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int playerHP = 1;
    [SerializeField]
    bool isDead; 

    private void Awake()
    {
        if(instance == null)
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
        playerHP = 1;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead())
        {
            AudioSystem.instance.PlaySound(AudioEnum.SFX_PlayerDeath);
            Destroy(gameObject);
            isDead = true;
        }
        else{

        }
    }

    public void takeDamage(int damage)
    {
        if (!isPlayerDead())
        {
            playerHP -= damage;
        }
    }

    public bool isPlayerDead()
    {
        if(playerHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    } 
    
}
