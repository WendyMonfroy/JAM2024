using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public Transform cameratr;

    private Rigidbody playerrb;
    private Transform playerRig;

    public int speed = 80;

    private float horizontalInput;
    private float verticalInput;

    [HideInInspector]
    public Vector2 inputs { get => new Vector2(horizontalInput, verticalInput);}

    // Start is called before the first frame update
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        playerRig = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        // get input keys
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move player transform
        playerrb.AddForce(cameratr.right * horizontalInput * Time.deltaTime * speed, ForceMode.VelocityChange);
        playerrb.AddForce(cameratr.forward * verticalInput * Time.deltaTime * speed, ForceMode.VelocityChange);

        // orientate player transform according to the movement direction
        OrientatePlayer();
    }

    private void OrientatePlayer()
    {
        int angle = 0;
        if (verticalInput > 0.1f)
        {
            if (horizontalInput > 0.5f)
            {
                angle = 45;
            }
            else if (horizontalInput < -0.5f)
            {
                angle = -45;
            }
            else
            {
                angle = 0;
            }
        }
        else if (verticalInput < -0.1f)
        {
            if (horizontalInput > 0.5f)
            {
                angle = 135;
            }
            else if (horizontalInput < -0.5f)
            {
                angle = -135;
            }
            else
            {
                angle = 180;
            }
        }

        if (horizontalInput > 0.01f && (verticalInput < 0.1f && verticalInput > -0.1f))
        {
            angle = 90;
        }
        if (horizontalInput < -0.01f && (verticalInput < 0.1f && verticalInput > -0.1f))
        {
            angle = -90;
        }
        playerRig.eulerAngles = cameratr.eulerAngles + new Vector3(0, angle, 0);
    }
}
