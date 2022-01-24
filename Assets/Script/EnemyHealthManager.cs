using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthManager : MonoBehaviour
{

    public int health;

    private int currHealth;

    private Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currHealth = health;
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemy Dies
        if(currHealth <= 0){
            Destroy(gameObject);
        }
        healthBar.value = currHealth;
        
        
    }

    public void hurtEnemy(int damage){
        currHealth -= damage;
    }
}
