using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 1.2f, -2.5f);
    public int rotationspeed = 5;

    private float mouseHorizontalInput = 0f;
    private float mouseVerticalInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position;

        // get input mouse
        mouseHorizontalInput += Input.GetAxis("Mouse X");
        mouseVerticalInput -= Input.GetAxis("Mouse Y");

        // orientate camera following the mouse
        transform.eulerAngles = new Vector3(0, mouseHorizontalInput, 0) * rotationspeed;
    }
}
