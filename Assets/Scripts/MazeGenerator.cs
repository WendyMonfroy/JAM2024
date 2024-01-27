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
    [SerializeField] private Transform Player;

    private List<Vector2> currentChunk = new List<Vector2>();

    /*Statics*/
    private static MazeGenerator _instance;
    public static List<GameObject> MazeBlocks => _instance._components;
    public static float BlockSize => 10f;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        UpdateMazeStarter();
    }

    public static void UpdateMaze()
    {
        _instance.UpdateMazeStarter();
    }

    private void UpdateMazeStarter()
    {
        StartCoroutine(_instance.GenerateMaze());
    }

    private IEnumerator GenerateMaze()
    {
        Vector3 playerPosition = Player.position;
        
        foreach (Transform child in transform)
        {
            MazeChunk c = child.GetComponent<MazeChunk>();
            if (c.GetDistanceTo(new Vector2(playerPosition.x, playerPosition.z)) > 400)
            {
                currentChunk.Remove(c._index);
                Destroy(child.gameObject);
            }
        }

        yield return null;
        
        float demiGridSize = 1.5f;
        float ratio = (MazeChunk.CHUNK_SIZE * BlockSize);
        
        int startX = (int)((playerPosition.x /ratio) - demiGridSize);
        int endX = (int)((playerPosition.x / ratio) + demiGridSize);
        int startY = (int)((playerPosition.z / ratio) - demiGridSize);
        int endY = (int)((playerPosition.z / ratio) + demiGridSize);
        
        for (int i = startX; i <= endX; i++)
        {
            for (int j = startY; j <= endY; j++)
            {
                Vector2 v = new Vector2(i, j);
                if (!currentChunk.Contains(v))
                {
                    GameObject chunk = Instantiate(_mazeChunk, transform);
                    chunk.GetComponent<MazeChunk>().GenerateChunk(new Vector2(i,j));
                    currentChunk.Add(v);
                }
            }
            yield return null;
        }
    }
}
