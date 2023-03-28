using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardAccel = 1f, reverse = .5f, maxSpeed = 50f, turnStrenght = 180, gravityForce = 10f, dragGround = 3f;
    private float speedInput, turnInput;

    public LayerMask whatIsGround;
    public float groundRayLenght = .5f;
    public Transform grounRayPoint;
    private bool grounded;
    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;
    public ParticleSystem[] dustril;
    public float maxEmission = 25f;
    private float emissionRate;
    [SerializeField] GameObject[] guns;
    

    //bool isControlEnables = true;

    // Start is called before the first frame update
    void Start()
    {

        rb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        IsProcessingFire();
        speedInput = 0;


        if (CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            speedInput = CrossPlatformInputManager.GetAxis("Vertical") * forwardAccel * 1000f;
        }
        else if
            (CrossPlatformInputManager.GetAxis("Vertical") < 0)
        {
            
            speedInput = CrossPlatformInputManager.GetAxis("Vertical") * reverse * 1000f;
        }
   
        turnInput = CrossPlatformInputManager.GetAxis("Horizontal");
        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime , 0f) ); //* Input.GetAxis("Vertical")
        }
        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);

        
       
        transform.position = rb.transform.position;
    }


    //void OnPlayerDeath()
    //{
    //    isControlEnables = false;
    //}
    private void FixedUpdate()
    {
        grounded = false;
        if (Physics.Raycast(grounRayPoint.position, -transform.up, out RaycastHit hit, groundRayLenght, whatIsGround))
        {
            grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        emissionRate = 0;
        if (grounded)
        {
            rb.drag = dragGround;


            if (Mathf.Abs(speedInput) > 0)
            {
                
                rb.AddForce(transform.forward * speedInput);
                
                emissionRate = maxEmission;
            }
        }
        else
        {
            rb.drag = 0.1f;
            rb.AddForce(100f * -gravityForce * Vector3.up);

        }
        



        foreach (ParticleSystem part in dustril)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }
    void IsProcessingFire()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActiveGuns();
        }
        else
        {
            DeActiveGuns();
        }
    }

    private void DeActiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ActiveGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }
    
}
