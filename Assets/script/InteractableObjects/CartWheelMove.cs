using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartWheelMove : MonoBehaviour
{
    [SerializeField]private GameObject[] waypoints;

    [SerializeField]private float speed;
    [SerializeField]private float rotateSpeed;
    private int currentIndex=0;
    void Update()
    {
        if(Vector2.Distance(waypoints[currentIndex].transform.position,transform.position)<.1f)
        {
            currentIndex++;
            rotateSpeed*=-1f;
            if(currentIndex>=waypoints.Length)
            {
                currentIndex=0;
                rotateSpeed*=1f;
            }
        }
        transform.position=Vector2.MoveTowards( transform.position,
                                                waypoints[currentIndex].transform.position,
                                                Time.deltaTime*speed);
        
        transform.Rotate(0,0,90f*Time.deltaTime*rotateSpeed);
        transform.Translate(new Vector3(0,0,waypoints[0].transform.position.z));
    }
}

