using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;

    public float lifeTime;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        //If enemy then do damage
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyHealthManager>().hurtEnemy(damage);
            Destroy(gameObject);
        }
    }
}
