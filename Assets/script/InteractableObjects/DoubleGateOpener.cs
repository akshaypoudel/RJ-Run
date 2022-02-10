using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGateOpener : MonoBehaviour
{
    private Transform Player;
    public float distanceFromPlayer;
    public float speed=10f;
    public GameObject leftGate;
    public GameObject rightGate;
    private GameObject Gate;
    Quaternion leftGateRotation=Quaternion.Euler(0,-90,0);
    Quaternion rightGateRotation=Quaternion.Euler(0,90,0);
    // bool canRight=true,canLeft=true;

    private void Start() {
        Player=GameObject.Find("Player").transform;
        // Gate=GameObject.Find("Gates");
        // leftGate=Gate.transform.GetChild(0).gameObject;
        // rightGate=Gate.transform.GetChild(1).gameObject;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player.position.x>=transform.position.x-distanceFromPlayer)
        {
            if(leftGate!=null)
            {
                if(leftGate.transform.rotation.y >= -90 && leftGate.transform.rotation.y <= 0)
                {
                    leftGate.transform.Rotate(0,-90*Time.deltaTime*speed,0);
                }
            }
            if(rightGate!=null)
            {
                if( rightGate.transform.rotation.y>=0 && rightGate.transform.rotation.y <= 90)
                {
                    rightGate.transform.Rotate(0,90*Time.deltaTime*speed,0);
                }
            }

        }
        // else if(Player.position.x<=transform.position.x+(distanceFromPlayer+10f))
        // {
        //     Destroy(this.gameObject);
        // }
        if(Player.position.x>=transform.position.x+10)
        {
            if(this.gameObject!=null)
                Destroy(this.gameObject);
        }
        
    }
}
