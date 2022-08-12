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

    private void Start() {
        Player=GameObject.Find("Player").transform;
    }
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
        if(Player.position.x>=transform.position.x+10)
        {
            if (this.gameObject != null)
                this.gameObject.SetActive(false);
        }
        
    }
}
