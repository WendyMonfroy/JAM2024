using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour
{
    /*Fields*/
    [SerializeField] private List<GameObject> _components;
    [SerializeField] private GameObject _mazeChunk;
    

    /*Statics*/
    private static MazeGenerator _instance;
    public static List<GameObject> MazeBlocks => _instance._components;
    public static float BlockSize => 10f;
    
    
    
    
    
    /*TMP*/
    private Vector3 PlayerPosition = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        
        int demiGridSize = 1;
        int startX = (int)PlayerPosition.x - demiGridSize;
        int endX = (int)PlayerPosition.x + demiGridSize;
        int startY = (int)PlayerPosition.y - demiGridSize;
        int endY = (int)PlayerPosition.y + demiGridSize;
        
        for (int i = startX; i <= endX; i++)
        {
            for (int j = startY; j <= endY; j++)
            {
                GameObject chunk = Instantiate(_mazeChunk, transform);
                chunk.GetComponent<MazeChunk>().GenerateChunk(new Vector2(i,j));
            }
        }
    }
}
