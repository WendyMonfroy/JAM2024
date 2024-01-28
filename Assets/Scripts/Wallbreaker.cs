using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class Wallbreaker : MonoBehaviour
{
    public LayerMask IgnoreMe;
    private int cooldown = 8;
    private bool canSBreak = true;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Input.GetMouseButtonDown(0) && canSBreak)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, ~IgnoreMe)) {
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.CompareTag("Wall"))
                {
                    objectHit.GetComponent<Wall>().DestroyWall();
                    StartCoroutine(CountDownCoolDown());
                }
            }
        }
    }

    private IEnumerator CountDownCoolDown()
    {
        canSBreak = false;
        yield return new WaitForSeconds(cooldown);
        canSBreak = true;
    }
}
