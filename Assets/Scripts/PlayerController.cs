using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidBody;
    Vector3 forceDirection;
    float forceScalar = 20f;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); //Gets the "body" of the player so we can manipulate it
        camera = Camera.main;  //This is the scene camera (Reserved and unique for Unity)
        //camera = new Camera();
        //rigidBody.transform.position = new Vector3(10f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {   
        CheckPlayerInput(); 
        MoveCamera();
        
    }

    //Check for keyboard input and translates it into movement
    void CheckPlayerInput() {
        forceDirection = Vector3.zero;
        float rotation = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            forceDirection += forceScalar*rigidBody.transform.forward;
        if (Input.GetKey(KeyCode.DownArrow))
            forceDirection += -forceScalar*rigidBody.transform.forward;

        if (Input.GetKey(KeyCode.A))
            forceDirection += -forceScalar*rigidBody.transform.right;
        if (Input.GetKey(KeyCode.D))
            forceDirection += forceScalar*rigidBody.transform.right;

        if (Input.GetKey(KeyCode.LeftArrow))//Rotate player
            rotation = -0.05f; //Speed of rotation left
        if (Input.GetKey(KeyCode.RightArrow))
            rotation = 0.05f;

        if (Input.GetKeyDown(KeyCode.LeftShift) && rigidBody.transform.position.y <= 0.41f) //Jump button
            forceDirection += Vector3.up * 2000f;

        rigidBody.AddTorque(new Vector3(0f, rotation, 0f), ForceMode.Impulse);
        rigidBody.AddForce(forceDirection);
    }

    //Camera movement
    void MoveCamera() {
        camera.transform.position = rigidBody.transform.position; //Sets the camera at the player position
        camera.transform.position += -3f*rigidBody.transform.forward; //Moves it 3 meter behind the player
        camera.transform.position += 2f*Vector3.up;
        camera.transform.LookAt(rigidBody.transform);  
    }
}
