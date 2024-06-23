using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowBound = -20;

    public static UnityEvent onLoser = new UnityEvent();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < lowBound)
        {
            Destroy(gameObject);
            onLoser.Invoke();
        }
    }
}
