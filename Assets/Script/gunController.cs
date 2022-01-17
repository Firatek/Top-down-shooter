using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{

    public bool isFiring;

    public BulletController bullet;

    public float bulletSpeed;

    public float rateOfFire;
        private float shotCounter;

    public Transform tipOfGun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring){
            shotCounter-= Time.deltaTime;
            if(shotCounter <= 0){
                shotCounter = rateOfFire;
                BulletController newBullet = Instantiate(bullet, tipOfGun.position, tipOfGun.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }else{
                shotCounter = 0;
            }
        }
        
        
    }
}
