using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    void Start()
    {
        //GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(1, 30), 0, 0) * tumble);
    }
}