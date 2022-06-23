using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed;
    public Rigidbody2D playerRB;

    Vector2 movement; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.y =  Input.GetAxisRaw("Vertical");
        playerRB.MovePosition(playerRB.position + movement * playerSpeed * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        
    }
}
