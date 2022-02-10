using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]private float speed;
    void FixedUpdate()
    {
        transform.Rotate(0,90f*Time.deltaTime*speed,0);
    }   
}
