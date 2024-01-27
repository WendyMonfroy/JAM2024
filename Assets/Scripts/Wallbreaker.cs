using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class Wallbreaker : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 middle = new Vector3(Screen.width / 2, (Screen.height * 2) /3, 0);
            Ray ray = Camera.main.ScreenPointToRay(middle);
        
            if (Physics.Raycast(ray, out hit)) {
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.CompareTag("Wall"))
                {
                    objectHit.GetComponent<Wall>().DestroyWall();
                }
            }
        }
    }
}
