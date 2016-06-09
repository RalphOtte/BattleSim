using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public float minHeight;
    public float maxHeight;
    private Vector3 spawnPos;


    // Use this for initialization
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        spawnPos = new Vector3(-10.0f, Random.Range(minHeight, maxHeight), 0.0f);
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], spawnPos, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
