using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    //private Object Char;


    CharacterController characterController;
    public float MovementSpeed = 12;
    public float Gravity = 1f;
    private float velocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //Char = this.gameObject;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.GetAxis("Horizontal"));
        print(Input.GetAxis("Vertical"));
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        gameObject.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        

        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * MovementSpeed * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }

        
    }
}

