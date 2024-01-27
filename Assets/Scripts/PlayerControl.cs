using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerrb;

    public int speed = 60;

    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input keys
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move player transform
        //transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed);
        playerrb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed, ForceMode.VelocityChange);

        // orientate player transform

    }
}
