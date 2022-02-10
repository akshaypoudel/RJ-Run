using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFalling : MonoBehaviour
{
    public float fallingSpeed;
    public float distanceFromPlayer;
    private Transform Player;
    Rigidbody _rigidBody;
    void Start()
    {
        Player=GameObject.Find("Player").transform;
        _rigidBody=this.gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
        if(_rigidBody==null)
        {
            Debug.Log("RigidBody is Null");
        }

    }

    void Update()
    {
        if(Player.position.x>=transform.position.x-distanceFromPlayer)
        {
            _rigidBody.constraints=RigidbodyConstraints.None;
        }
    }
}
