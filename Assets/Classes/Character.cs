using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //private properties
    private float xRotation { get; set; }
    private float yRotation { get; set; }
    private Camera Cam { get; set; }
    private Rigidbody RB { get; set; }



    //public properites


    public KeyCode TurnLeft { get; set; } = KeyCode.A;
    public KeyCode TurnRight { get; set; } = KeyCode.D;

    public KeyCode PlayerJump { get; set; } = KeyCode.Space;

    public int MouseButtonFire { get; set; } = 0;
    public int MouseButtonTurn { get; set; } = 1;


    public float MoveSpeed { get; set; } = 5;
    public float JumpVelocity { get; set; } = 5;

    public string SelectedArrow { get; set; } //change type to bow once created.
    public List<string> Arrows { get; set; } //change type to bow once created.

    public string SelectedBow { get; set; } //change type to bow once created.
    public List<string> Bows { get; set; } //change type to bow once created.
    public int Strength { get; set; }
    public int Stamina { get; private set; }

    public List<string> Gear { get; set; } // future placeholder. Change type to "GearItem" once created.

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Pitch");
        //float mouseY = Input.GetAxis("Yaw");

        //float Forward = Input.GetAxis("MoveForward");
        //float Right = Input.GetAxis("MoveRight");


        //turn if right-click, A, or D is held
        if (Input.GetKey(TurnLeft))
        {
            Turn(-45, Input.GetAxis("Yaw"));
        }
        else if (Input.GetKey(TurnRight))
        {
            Turn(45, Input.GetAxis("Yaw"));
        }
        else if (Input.GetMouseButton(MouseButtonTurn))
        {
            // Turn(mouseX, mouseY);
            Turn(Input.GetAxis("Pitch"), Input.GetAxis("Yaw"));
        }

        if (Input.GetMouseButton(MouseButtonFire))
        {
            //SelectedBow.Draw()
        }
        if (Input.GetMouseButtonUp(MouseButtonFire))
        {
            //Fire()
        }

        if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            xRotation = 0;
            yRotation = 0;
        }

        //jump handler
        if (Input.GetKeyDown(PlayerJump))
        {
            //RB.velocity = new Vector3(0, JumpVelocity, 0);
            Jump();
        }

        //move
        Move(Input.GetAxis("MoveForward"), Input.GetAxis("MoveRight"));

        //debug:
        //print("MouseX: " + mouseX);
        //print("MouseY: " + mouseY);
        //print("Forward: " + Forward);
        //print("Right: " + Right);
        //print(yRPos);
    }

    /// <summary>
    /// Fire the bow - either when fire button released or stamina runs out.
    /// </summary>
    public void Fire()
    {
        //check stamina against strength for fire's % rating

        //selectedBow.fire(float %)
        
    }

    public void Turn(float x, float y)
    {
        yRotation += y;
        xRotation += x;
        
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
    }

    public void Move(float f, float r)
    {
        gameObject.transform.Translate(
            (Vector3.right * (r * MoveSpeed) 
            + Vector3.forward * (f * MoveSpeed)
            ) * Time.deltaTime);
    }

    public void Jump()
    {
        if (RB.velocity.y < 0.1 && RB.velocity.y > -0.1)
        {
            RB.velocity = new Vector3(0, JumpVelocity, 0);
        }
        
    }
}
