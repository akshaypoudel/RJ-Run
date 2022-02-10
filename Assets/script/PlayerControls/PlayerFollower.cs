using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField]private Transform Player;
    public Transform playerFollow;

    public Vector3 offset;
    
    void LateUpdate()
    {
        transform.position=Player.position+offset;

        // transform.LookAt(playerFollow);
    }
}
