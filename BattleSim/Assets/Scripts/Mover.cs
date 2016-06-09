using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float minSpeed;
    public float maxSpeed;

	void Update ()
    {
        transform.position += new Vector3(Random.Range(minSpeed, maxSpeed) * Time.deltaTime, 0.0f, 0.0f);
    }
}
