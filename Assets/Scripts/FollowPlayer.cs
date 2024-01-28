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

    public Transform camPos, cam;

    Vector3 lookAtPos;

    // Start is called before the first frame update
    void Start()
    {
        lookAtPos = new Vector3(
            transform.position.x,
            transform.position.y + camPos.position.y + camPos.forward.y * Vector3.Distance(transform.position, new Vector3(
                camPos.position.x,
                transform.position.y,
                camPos.position.z)),
            transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(camPos.position, transform.position + lookAtPos);
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

        RaycastHit hit;
        Physics.Raycast(transform.position + lookAtPos, (camPos.position - transform.position - lookAtPos), out hit, Vector3.Distance(camPos.position, transform.position + lookAtPos));
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Wall")
            {
                Vector3 newPos = (hit.point - (transform.position + lookAtPos)) * 0.9f;
                cam.position = (transform.position + lookAtPos) + newPos;
            }
        }
        else
        {
            cam.position = camPos.position;
        }
    }
}
