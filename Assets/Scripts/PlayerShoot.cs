using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform leftGun;
    public Transform rightGun;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        ShootLeft();
        ShootRight();
    }
    void ShootRight()
    {  
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("Shoot Right");
            Instantiate(bullet, rightGun.transform.position, Quaternion.identity).GetComponent<Bullet>().travelRight();
            AudioSystem.instance.PlaySound(AudioEnum.SFX_Gunshot);
        }
    }
    void ShootLeft()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("Shoot Left");
            Instantiate(bullet, leftGun.transform.position, Quaternion.identity).GetComponent<Bullet>().travelLeft();
            AudioSystem.instance.PlaySound(AudioEnum.SFX_Gunshot);
        }
    }
}
