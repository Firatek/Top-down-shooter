using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCam;
    public gunController theGun;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame dependant of frame rate
    void Update()
    {
        //Movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Make the player look at mouse pos
        //Create Ray that intersects with new groundPlane
        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        //Check intersection of ray and plane
        if(groundPlane.Raycast(cameraRay, out rayLength)){
            Vector3 lookAt = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, lookAt);
            //y need to be on the same level as the player to prevent him lookind down/up
            transform.LookAt(new Vector3(lookAt.x, transform.position.y, lookAt.z));
        }

        //Fire gun, 0 = left click
        if(Input.GetMouseButtonDown(0)){
            theGun.isFiring = true;
        }
        if(Input.GetMouseButtonUp(0)){
            theGun.isFiring = false;
        }
    }

    //Happens every 0.2s
    void FixedUpdate() {
        //Move body
        myRigidBody.velocity = moveVelocity;
         
    }
}
