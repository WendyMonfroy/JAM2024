using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class Wallbreaker : MonoBehaviour
{
    public LayerMask IgnoreMe;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        //Debug.Log(transform.forward);
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, ~IgnoreMe)) {
                GameObject objectHit = hit.transform.gameObject;
                Debug.Log(objectHit);
                if (objectHit.CompareTag("Wall"))
                {
                    objectHit.GetComponent<Wall>().DestroyWall();
                }
            }
        }
    }
}
