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
                if (i == 0 && j == 0)
                {
                    continue;
                }
                GameObject piece = GenerateMazePiece(i, j);
                piece.transform.localPosition = new Vector3(i * _sizeUnit, 0, j * _sizeUnit);
            }
        }
        
    }

    private GameObject GenerateMazePiece(int x, int y)
    {
        int rotScale = Random.Range(0,5);
        int pieceNumber = Random.Range(0, 3);

        if (x == 0 || y == 0)
        {
            pieceNumber = Random.Range(1, 3);
        }

        if (x == 0)
        {
            rotScale = 0;
        }
        
        if (y == 0)
        {
            rotScale = 3;
        }
        
        GameObject piece = Instantiate( _components[pieceNumber], _tr);
        piece.transform.Rotate(Vector3.up, rotScale * 90);
        return piece;
    }
}
