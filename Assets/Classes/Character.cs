using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float xRotation;
    private float yRotation;
    public float MoveSpeed = 5;
    public float JumpVelocity = 5;
    private Camera Cam;
    private Rigidbody RB;
    

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Pitch");
        float mouseY = Input.GetAxis("Yaw");

        yRotation += mouseY;
        xRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -45, 45); //max turn speed
        xRotation = Mathf.Clamp(xRotation, -90, 90); //max turn speed

        gameObject.transform.Rotate(new Vector3(0f, xRotation, 0.0f) * Time.deltaTime);

        var yRPos = Cam.transform.rotation.eulerAngles.x;

        if (yRPos < 280 && yRPos >= 200 && yRotation > 0)
        {
            // do nothing
            print("upper clamp");
        }
        else
        {
            if (yRPos >= 60 && yRPos < 200 && -yRotation > 0)
            {
                //do nothing?
                print("lower clamp");
            }
            else
            {
                Cam.transform.Rotate(new Vector3(-yRotation, 0, 0) * Time.deltaTime);
            }
        }
        
        // player movement - forward, backward, left, right
        float Right = Input.GetAxis("MoveRight");// * MoveSpeed/1000;

        float Forward = Input.GetAxis("MoveForward");// * MoveSpeed/1000;

        //jump handler
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.velocity = new Vector3(0, JumpVelocity, 0);
        }
        
        gameObject.transform.Translate((Vector3.right * (Right * MoveSpeed) + Vector3.forward * (Forward * MoveSpeed)) * Time.deltaTime);

        //debug:
        //print("MouseX: " + mouseX);
        //print("MouseY: " + yRotation);
        //print("Forward: " + Forward);
        //print("Right: " + Right);
        //print(yRPos);


    }
}
