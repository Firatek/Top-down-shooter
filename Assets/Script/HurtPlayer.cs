using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public int dmgToGive;


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject
            .GetComponent<PlayerHealthController>()
            .HurtPlayer(dmgToGive);
        }
        
    }
}
