using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform playerTransform;

    void Start()
    {
        
    }

    void Update()
    {
        var x = playerTransform.position.x;
        var y = playerTransform.position.y+1f;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
