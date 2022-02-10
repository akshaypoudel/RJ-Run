using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    // public bool isAnimated = false;

    // public bool isRotating = false;
    // public bool isFloating = false;
    // public bool isScaling = false;

    // public Vector3 rotationAngle;
    // public float rotationSpeed;

    // public Vector3 floatPos;
    // // public float floatPos.y;
    // private bool goingUp = true;
    // public float floatRate;
    // private float floatTimer;
   
    // public Vector3 startScale;
    // public Vector3 endScale;

    // private bool scalingUp = true;
    // public float scaleSpeed;
    // public float scaleRate;
    // private float scaleTimer;
    // public float timeCounter;

/*	void Update () {
    
        if(isAnimated)
        {
            if(isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if(isFloating)
            {
                floatTimer += Time.deltaTime*timeCounter;
                Vector3 moveDir = floatPos;
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatPos.y = -floatPos.y;
                }

                else if(!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatPos.y = +floatPos.y;
                }
            }

            if(isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if(scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }

    }*/

}







