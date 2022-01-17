using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public int startingHealth;
    private int currentHealth;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;
    // Start is called before the first frame update
    void Start()
    {   
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
        if(flashCounter > 0){
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0){
                rend.material.SetColor("_Color", storedColor);
            }
        }
        
    }

    public void HurtPlayer(int dmg){
        currentHealth -= dmg;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }
}
