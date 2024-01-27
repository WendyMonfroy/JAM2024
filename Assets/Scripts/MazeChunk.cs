using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeChunk : MonoBehaviour
{
    public static int CHUNK_SIZE => 10;
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
        int rotScale = Random.Range(0,4);
        int pieceNumber = Random.Range(0,MazeGenerator.MazeBlocks.Count);

        Vector2 nx = GetBlockOpenings(x-1, y);
        Vector2 ny = GetBlockOpenings(x, y-1);

        Vector2 condition = Vector2.zero;

        if (nx.x > 0)
        {
            condition.x = 1;
        }
        if (ny.y > 0)
        {
            condition.y = 1;
        }

        if (pieceNumber != 0)
        {
            
            if (condition == Vector2.one)
            {
                switch (pieceNumber)
                {
                    case 1:
                        pieceNumber = 0;
                        break;
                    case 2:
                        rotScale = 2;
                        break;
                    case 3:
                        rotScale = Random.Range(1, 3);
                        break;
                }
            }
            else
            {
                if (Mathf.RoundToInt(condition.x) == 1)
                {
                    switch (pieceNumber)
                    {
                        case 1:
                            rotScale = 0;
                            break;
                        case 2:
                            rotScale = Random.Range(2, 4);
                            break;
                        case 3:
                            if (rotScale == 0)
                            {
                                rotScale += Random.Range(1, 4);
                            }
                            break;
                    }
                }
                if (Mathf.RoundToInt(condition.y) == 1)
                {
                    switch (pieceNumber)
                    {
                        case 1:
                            rotScale = 1;
                            break;
                        case 2:
                            rotScale = (Random.Range(2, 4) +2)%4;
                            break;
                        case 3:
                            break;
                    }
                }
            }
        }
        
        
        GameObject piece = Instantiate( MazeGenerator.MazeBlocks[pieceNumber], transform);

        piece.transform.Rotate(Vector3.up, rotScale * 90);
        return piece;
    }

    public Vector2 GetBlockOpenings(int x, int y)
    {
        Vector2 op = new Vector2();
        int v = x * CHUNK_SIZE + y;
        if (v < transform.childCount && v > 0)
        {
            Transform child = transform.GetChild(v);
            op = child.GetComponent<MazeBlock>().Openings;
        }
        return op;
    }
}
