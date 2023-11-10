using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private Vector3 startPosition;
    public float maxDistance = 3;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        direction = -1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += direction * transform.forward*0.01f;
        if(Vector3.Distance(startPosition, transform.position) > maxDistance)
            direction = 1f;
        
    }
}
