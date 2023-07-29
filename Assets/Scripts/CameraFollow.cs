using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Camera seguir 
    public Transform objectToFollow;
    public Vector3 offset;

    void Start()
    {
        offset = objectToFollow.position - this.transform.position;
    }

    void Update()
    {
        this.transform.position = objectToFollow.transform.position - offset;
    }
}
