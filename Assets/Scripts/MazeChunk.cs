using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeChunk : MonoBehaviour
{
    private static int CHUNK_SIZE = 10;
    public Vector2 _index;
    
    public void GenerateChunk(Vector2 index)
    {
        _index = index;
        transform.position = new Vector3(_index.x * CHUNK_SIZE * MazeGenerator.BlockSize , 0, _index.y * CHUNK_SIZE * MazeGenerator.BlockSize);
        for (int i = 0; i < CHUNK_SIZE; i++)
        {
            for (int j = 0; j < CHUNK_SIZE; j++)
            {
                GameObject piece = GenerateMazePiece(i, j);
                piece.transform.localPosition = new Vector3(i * MazeGenerator.BlockSize, 0, j * MazeGenerator.BlockSize);
            }
        }
    }
    
    private GameObject GenerateMazePiece(int x, int y)
    {
        int rotScale = Random.Range(0,5);
        int pieceNumber = Random.Range(0, 3);
        
        if (x == 0)
        {
            rotScale = 0;
        }
        
        if (y == 0)
        {
            rotScale = 3;
        }
        
        GameObject piece = Instantiate( MazeGenerator.MazeBlocks[pieceNumber], transform);
        piece.transform.Rotate(Vector3.up, rotScale * 90);
        return piece;
    }
}
