using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMover : MonoBehaviour
{
    private Transform Player;
    private Rigidbody _rigidbody;
    public float tyreRotateSpeed;
    public float tyreMoveSpeed;
    public float distanceFromPlayer;
    void Start()
    {
        Player=GameObject.Find("Player").transform;
        _rigidbody=GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.Rotate(0,0,90*Time.deltaTime*tyreRotateSpeed);

        if(Player.position.x>=transform.position.x-distanceFromPlayer)
        {
            transform.Translate(Vector3.left*Time.deltaTime*tyreMoveSpeed,Space.World);
        }        
    }
}
