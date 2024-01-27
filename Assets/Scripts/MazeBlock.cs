using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBlock : MonoBehaviour
{
    [SerializeField] private Vector2 _openings;
    private Vector2 _trueOpening;

    public Vector2 Openings => _trueOpening;

    private void Start()
    {
        float angle = (transform.rotation.eulerAngles.y + 360) % 360;
        switch (angle)
        {
            case 90 :
                _trueOpening = new Vector2(-1 *_openings.y,_openings.x);
                break;
            case 180 :
                _trueOpening = new Vector2( -1 * _openings.x, -1 * _openings.y);
                break;
            case 270 :
                _trueOpening = new Vector2( _openings.y, -1 * _openings.x);
                break;
            default:
                _trueOpening = _openings;
                break;
        }
    }
}
