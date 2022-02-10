using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerScript : MonoBehaviour
{
    private Animator animator;
    private Transform Player;
    [SerializeField]private float distanceFromPlayer;
    [SerializeField]private float moveSpeed;
    private bool canMove=true;

    void Start()
    {
        animator=GetComponent<Animator>();
        Player=GameObject.Find("Player").transform;
        canMove=true;
    }
    void Update()
    {
        if(Player.position.x>=transform.position.x-distanceFromPlayer)
        {
            if(canMove) 
            {
                transform.Translate(Vector3.left*Time.deltaTime*moveSpeed,Space.World);
            }
            animator.SetBool("isRunning",true);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player"))
        {
            canMove=false;
            animator.SetBool("isRunning",false);
            animator.SetBool("Hit",true);
        }
    }
}
