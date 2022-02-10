using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovingScript : MonoBehaviour
{
    private Transform Player;
    private Rigidbody _rigidBody;
    private GameObject[] carTyres;
    public float speed;
    public float playerDistanceFromCar;
    public float tyreMovingSpeed;
    private GameObject Car;
    private GameObject wheel1;
    private GameObject wheel2;
    private GameObject wheel3;
    private GameObject wheel4;

    void Start()
    {
        Player=GameObject.Find("Player").transform;
        _rigidBody=GetComponent<Rigidbody>();
        Car=GameObject.FindWithTag("Car");
        if(Car!=null)
        {
            wheel1=Car.transform.GetChild(0).gameObject;
            wheel2=Car.transform.GetChild(1).gameObject;
            wheel3=Car.transform.GetChild(2).gameObject;
            wheel4=Car.transform.GetChild(3).gameObject;
        }
        // Debug.Log(wheel1.name);
    }

    void Update()
    {
        if(Player.position.x>=transform.position.x-playerDistanceFromCar)
        {
            _rigidBody.velocity=Vector3.left*speed;
        }
        if(wheel1 != null)
            wheel1.transform.Rotate(90f*Time.deltaTime*tyreMovingSpeed,0,0);
        if(wheel2!=null)
            wheel2.transform.Rotate(90f*Time.deltaTime*tyreMovingSpeed,0,0);
        if(wheel3!=null)
            wheel3.transform.Rotate(90f*Time.deltaTime*tyreMovingSpeed,0,0);
        if(wheel4!=null)
            wheel4.transform.Rotate(90f*Time.deltaTime*tyreMovingSpeed,0,0);
        
    }
}
