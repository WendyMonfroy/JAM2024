using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _components;
    private Transform _tr;
    private float _sizeUnit = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<Transform>();
        int gridSize = 20;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                int nb = Random.Range(0, 3);
                GameObject piece = Instantiate(_components[nb], _tr);
                piece.transform.localPosition = new Vector3(i * _sizeUnit, 0, j * _sizeUnit);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
