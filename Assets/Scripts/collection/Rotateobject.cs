using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateobject: MonoBehaviour
{
    public float rotateSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
