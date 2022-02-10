using UnityEngine;

public class TouchRotation : MonoBehaviour {
    
    private Touch touch;
    private Vector2 touchPos;
    private Quaternion rotationY;
    [SerializeField]private float rotateSpeed=0.5f;

    private void FixedUpdate() {
        #if UNITY_ANDROID
            touchRotate();
        #endif
    }

    public void touchRotate()
    {
        if(Input.touchCount>0)          
        {
            touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Moved)
            {
                rotationY=Quaternion.Euler(0f,-touch.deltaPosition.x*rotateSpeed,0f);
                transform.rotation=rotationY*transform.rotation;
            }

        }
    }
}