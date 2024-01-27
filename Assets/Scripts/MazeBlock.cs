using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBlock : MonoBehaviour
{
    [SerializeField] private Vector2 _openings;

    public Vector2 Openings => GetTrueOpening();

    private Vector2 GetTrueOpening()
    {
        float angle = (transform.rotation.eulerAngles.y + 360) % 360;
        Vector2 trueOpening = _openings;
        switch (angle)
        {
            case 90 :
                trueOpening = new Vector2(-1 *_openings.y,_openings.x);
                break;
            case 180 :
                trueOpening = new Vector2( -1 * _openings.x, -1 * _openings.y);
                break;
            case 270 :
                trueOpening = new Vector2( _openings.y, -1 * _openings.x);
                break;
        }

        return trueOpening;
    }
}
