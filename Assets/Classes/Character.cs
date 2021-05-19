using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update


    // horizontal rotation speed
    //public float horizontalSpeed = .5f;
    //// vertical rotation speed
    //public float verticalSpeed = .5f;
    private float xRotation;
    private float yRotation;
    //private Camera cam;
    //CharacterController characterController;
    ////public float MovementSpeed = 0.2f;
    //public float Gravity = 9.8f;
    //private float velocity = 0;
    //Vector3 MoveDirection;
    public float MoveSpeed = 13;
    Rigidbody rb;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    cam = Camera.main;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;
        //characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Pitch");
        float mouseY = Input.GetAxis("Yaw");

        yRotation += mouseY;
        xRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90);


        //cam.transform.localEulerAngles = new Vector3(-xRotation, yRotation, 0.0f) * Time.deltaTime;
        gameObject.transform.Rotate(new Vector3(0f, xRotation, 0.0f) * Time.deltaTime);
        //rb.MoveRotation(new Quaternion())
        


        // player movement - forward, backward, left, right
        float Right = Input.GetAxis("MoveRight") * MoveSpeed/1000;

        float Forward = Input.GetAxis("MoveForward")* MoveSpeed/1000;

        //MoveDirection = (Right * transform.right + Forward * transform.forward).normalized;

        ////characterController.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);


        gameObject.transform.Translate((Vector3.right * Right + Vector3.forward * Forward));


        ////gameObject.transform.Translate(Vector3.right * horizontal + Vector3.forward * vertical);
        //print(characterController.isGrounded);
        //// Gravity
        //if (characterController.isGrounded)
        //{
        //    //velocity = 0;
        //    characterController.transform.Translate(new Vector3(0, 0, 0));
        //}
        //else
        //{
        //    velocity = -Gravity * Time.deltaTime;
        //    //characterController.Move(new Vector3(0, velocity, 0));
        //    characterController.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);

        //}
        
    }


    //private void FixedUpdate()
    //{
    //    Move();
    //}

    //private void Move()
    //{
    //    Vector3 vector = new Vector3(0, -1, 0);
    //    //rb.MovePosition((MoveDirection * MoveSpeed * Time.deltaTime));
    //    //rb.MovePosition += vector;
    //}
}
