using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float velRotation = 1f;
    //Rotationa objeto no eixo y
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.up, velRotation);
    }
}
