using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    private Rigidbody asteroidRb;
    // Start is called before the first frame update
    void Start()
    {
     asteroidRb = GetComponent<Rigidbody>();
     asteroidRb.AddTorque(Random.Range(-2, 2), Random.Range(2, 2), Random.Range(-2, 2), ForceMode.Impulse);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
