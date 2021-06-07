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

    public float currentStamina = 100;
    public float currentStrength = 0;

    public bool reverse = false;

    public float staminaRegenRate = 0.012f;
    public float pullStrength = 1f;

    public int reverseCount = 0;

    //public properites


    public KeyCode TurnLeft = KeyCode.A;
    public KeyCode TurnRight = KeyCode.D;

    public KeyCode PlayerJump = KeyCode.Space;

    public int MouseButtonFire = 0;
    public int MouseButtonTurn = 1;

    public StrengthBar strengthBar;
    public StaminaBar staminaBar;

    public float MoveSpeed = 5;
    public float JumpVelocity = 5;

    public GameObject SelectedArrow; //change type to arrow once created.
    public List<string> Arrows; //change type to arrow once created.

    public Bow SelectedBow; //change type to bow once created.
    public List<Bow> Bows; //change type to bow once created.
    public int Strength = 100;
    public int Stamina = 100;

    public List<string> Gear { get; set; } // future placeholder. Change type to "GearItem" once created.

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        RB = GetComponent<Rigidbody>();
        //strengthBar = GetComponent<StrengthBar>();
        strengthBar.SetMaxStrength(Strength);


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
        } else
        {
            RB.constraints = RigidbodyConstraints.FreezeRotation;
        }

        //Initial pull of bow by pushing "space"
        if (Input.GetMouseButtonDown(MouseButtonFire))
        {
            //Reset strength bar
            reverse = false;
            currentStrength = 0.0f;
            strengthBar.SetMaxStrength(Strength);
            pullStrength = 0.2f;
        }

        if (Input.GetMouseButton(MouseButtonFire))
        {
            SelectedBow.Draw(SelectedArrow);
            Pull(pullStrength);
            Fatigue(0.02f); //TODO! Keep as flat rate?
        }
        if (Input.GetMouseButtonUp(MouseButtonFire))
        {
            Fire();
        }

        if (Input.GetMouseButtonUp(MouseButtonTurn) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
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

        UpdateStamina();
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

        SelectedBow.Fire(currentStrength);
        
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
                
                if (SelectedBow.NockedArrow != null)
                {
                    SelectedBow.NockedArrow.transform.rotation = SelectedBow.LP.transform.rotation;
                }
                
            }
        }
    }

    public void Move(float f, float r)
    {
        gameObject.transform.Translate(
            (Vector3.right * (r * MoveSpeed) 
            + Vector3.forward * (f * MoveSpeed)
            ) * Time.deltaTime);

        if (SelectedBow.NockedArrow != null)
        {
            SelectedBow.NockedArrow.transform.position = SelectedBow.LP.transform.position;
        }
        //NockedArrow.transform.position = LP.transform.position;
    }

    public void Jump()
    {
        if (RB.velocity.y < 0.1 && RB.velocity.y > -0.1)
        {
            RB.velocity = new Vector3(0, JumpVelocity, 0);
        }
        
    }

    void UpdateStamina()
    {
        //When stamina reaches 0, slow down regen rate
        if (currentStamina <= 0)
        {
            staminaRegenRate = 0.007f;
        }
        else if (currentStamina >= 25 && currentStamina < 60)
        { //Once stamina reaches 25 again, increase regen rate
            staminaRegenRate = 0.01f;
        }
        else if (currentStamina >= 60)
        { //Once stamina reaches 60 again, increase regen rate
            staminaRegenRate = 0.012f;
        }

        //Continually recharge stamina guage
        if (currentStamina < 100)
        {
            currentStamina += staminaRegenRate;
            staminaBar.SetStamina(currentStamina);
        }
    }

    //Method for draining stamina guage
    void Fatigue(float staminaLoss)
    {
        currentStamina -= staminaLoss;
        //Don't allow stamina to go below -10
        if (currentStamina < -10)
        {
            currentStamina = -10;
        }
        staminaBar.SetStamina(currentStamina);
    }

    //Method for determining current strength
    void Pull(float strength)
    {
        //Based on current strength, decrease pull strength rate
        switch (currentStrength)
        {
            case 50:
                pullStrength *= 0.5f;
                break;
            case 75:
                pullStrength *= 0.85f;
                break;
        }

        //In reverse, lower strength.  This happens after strength reaches 100 for the first time.
        if (reverse)
        {
            currentStrength -= strength;
            switch (reverseCount)
            {
                case 0:  //On the first reverse, do not go lower than 50 strength
                    if (currentStrength < 50)
                    {
                        reverseCount++;
                        reverse = false;
                    }
                    break;
                case 1:  //On the second reverse, do not go lower than 60 strength
                    if (currentStrength < 60)
                    {
                        reverseCount++;
                        reverse = false;
                    }
                    break;
                case 2:  //On the third or more reversals, do not go lower than 65 strength
                    if (currentStrength < 65)
                    {
                        reverse = false;
                    }
                    break;
            }
        }
        else
        { //Increase strength
            currentStrength += strength;
            if (currentStrength >= 100)
            {
                reverse = true;
            }
        }
        if (currentStamina <= 0.0f)
        {
            currentStrength = 0.0f;
        }
        strengthBar.SetStrength(currentStrength);
    }
}
