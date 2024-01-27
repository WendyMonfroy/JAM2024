using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _components;
    [SerializeField] private GameObject _mazeChunk;

    private static List<GameObject> mazeBlocks;
    public static List<GameObject> MazeBlocks => mazeBlocks;
    public static float BlockSize => 10f;
    private Vector3 PlayerPosition = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        mazeBlocks = _components;
        
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
