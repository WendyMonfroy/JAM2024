using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform cameratr;

    private Rigidbody playerrb;
    private Transform playerRig;

    public int speed = 80;

    private float horizontalInput;
    private float verticalInput;


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
        //playerrb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed, ForceMode.VelocityChange);
        playerrb.AddForce(cameratr.right * horizontalInput * Time.deltaTime * speed, ForceMode.VelocityChange);
        playerrb.AddForce(cameratr.forward * verticalInput * Time.deltaTime * speed, ForceMode.VelocityChange);

        // orientate player transform according to the movement direction
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            playerRig.eulerAngles = cameratr.eulerAngles;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
        {
            playerRig.eulerAngles = cameratr.eulerAngles + new Vector3(0, 180, 0);
        }
    }
}
