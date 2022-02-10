using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTiger : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator=gameObject.GetComponent<Animator>();
    }
    private void OnMouseDown() {
        animator.SetBool("Roar",true);
    }
    private void OnMouseUp() {
        animator.SetBool("Roar",false);
    }
}
