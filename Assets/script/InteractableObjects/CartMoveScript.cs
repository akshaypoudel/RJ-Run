using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMoveScript : MonoBehaviour
{
    private Transform Player;
    [SerializeField]private float distanceFromPlayer;
    [SerializeField]private float speed;
    [SerializeField]private float tyreMovingSpeed;
    private GameObject wheel1;
    private GameObject wheel2;
    private GameObject wheel3;
    private GameObject wheel4;
    private GameObject Cart;
    void Start()
    {   
        Player=GameObject.Find("Player").transform;
        Cart=GameObject.FindWithTag("Car");
        if(Cart!=null)
        {
            wheel1=Cart.transform.GetChild(0).gameObject;
            wheel2=Cart.transform.GetChild(1).gameObject;
            wheel3=Cart.transform.GetChild(2).gameObject;
            wheel4=Cart.transform.GetChild(3).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x>=transform.position.x-distanceFromPlayer)
        {
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
        if(wheel1 != null)
            wheel1.transform.Rotate(0,0,90f*Time.deltaTime*tyreMovingSpeed);
        if(wheel2!=null)
            wheel2.transform.Rotate(0,0,90f*Time.deltaTime*tyreMovingSpeed);
        if(wheel3!=null)
            wheel3.transform.Rotate(0,0,90f*Time.deltaTime*tyreMovingSpeed);
        if(wheel4!=null)
            wheel4.transform.Rotate(0,0,90f*Time.deltaTime*tyreMovingSpeed);
    }
}
