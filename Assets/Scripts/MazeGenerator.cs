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
                GetBorder(i, j);
                chunk.GetComponent<MazeChunk>().GenerateChunk(new Vector2(i,j));
            }
        }
    }

    private List<List<Vector2>> GetBorder(int x, int y)
    {
        List<List<Vector2>> list = new List<List<Vector2>>();


        for (int i = 0; i < MazeChunk.CHUNK_SIZE; i++)
        {
            for (int j = 0; j < MazeChunk.CHUNK_SIZE; j++)
            {
                
            } 
        }

        return list;
    }
}
