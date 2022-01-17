using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidBody;

    public GameObject target;

    private Vector3 moveVelocity;

    public PlayerController thePlayer;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }

    private void OnCollisionEnter(Collision other) {
    }

    private void FixedUpdate() {
        myRigidBody.velocity = (transform.forward * moveSpeed);
    }
}
