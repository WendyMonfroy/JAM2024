using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableMemesSpawner : MonoBehaviour
{
    public Vector3 spawnPoint;
    public float spawnRadius;

    public PickabableMeme prefab;

    public MemeTemplate[] memeTemplates;

    private void Start()
    {
        spawnPickableMeme(0.3f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + spawnPoint, 0.1f);
        Gizmos.DrawWireSphere(transform.position + spawnPoint, spawnRadius);
    }

    public void spawnPickableMeme(float proba)
    {
        if (Random.value < proba)
        {
            float a = Random.Range(0, 6.28f);
            float n = Random.value;
            Vector3 pt = spawnPoint + Vector3.forward * Mathf.Sin(a) * n * spawnRadius + Vector3.right * Mathf.Cos(a) * n * spawnRadius;

            PickabableMeme me = PickabableMeme.Instantiate(prefab, transform.position + pt, Quaternion.identity, transform);
            me.template = memeTemplates[Random.Range(0, memeTemplates.Length)];
            me.transform.Rotate(Vector3.up * a * 180 / 3.14f);
            me.init();
        }
    }
}
