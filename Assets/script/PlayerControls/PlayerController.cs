using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left,Mid,Right}
public class PlayerController : MonoBehaviour
{
    #region StandaloneInput
    private SIDE enumSide=SIDE.Mid;
    [SerializeField]
    private float sidescrollSpeed;
    public AudioSource CoinSoundEffect;
    [SerializeField] private ParticleSystem CollectEffect=null;
    public GameObject PauseMenu;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpHeight;
    public Animator animator;
    public Rigidbody _rigidBody;
    public CapsuleCollider rjCollider;
    public AnimationClip anim;

    [SerializeField]
    private float ZPos;
    private float NewXPos=0f;
    
    private bool swiptRight;
    private bool swiptLeft;
    private bool isGrounded=true;
    private bool isJumping=false;

    public float colliderHeightWhenRolling;
    public float normalHeight;
    public Vector3 normalPosition;
    public Vector3 colliderYPosWhenRolling;



    private bool isRolling = true;
    [SerializeField]
    private float speedIncreaser; // how much speed would increase every frame 
    [SerializeField]
    private float distanceToIncreaseSpeed; // at which distance speed would start to increase
    [SerializeField]
    private float maxSpeedToIncrease;  // max amount of speed to be increased


    #endregion
    #region Mobilecontrols
        [Header("Mobile Controls")]
        private Vector2 startTouchPosition;
        private Vector2 currentPosition;
        private Vector2 endTouchPosition;
        private bool stopTouch = false;

        [SerializeField]private float swipeRange;
        [SerializeField]private float jumpRange;
    [SerializeField] private float rollSpeed;
        [SerializeField]private float tapRange;
    #endregion
    //FUNCTIONS
    void Start()
    {
        isRolling = false;
        NewXPos=0f;
    }
    void Update()
    { 
        StandAloneInput();
        if((Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && !isRolling && !isJumping)
        {
            isJumping = true;
            AndroidJump();  
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded && !isRolling) 
        {
            isRolling = true;
            
            Roll();
            
        }
        //MobileControls();
        MovePlayer();
    }
    private void Roll()
    {
        rjCollider.height = colliderHeightWhenRolling;
        rjCollider.center = colliderYPosWhenRolling;
        animator.SetTrigger("Roll");
        StartCoroutine(BackToNormal());
    }
    private IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(1.2f);
        isRolling = false;
        rjCollider.height = normalHeight;
        rjCollider.center = normalPosition;
    }
    private void MobileControls()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {

                if (Distance.x < -swipeRange)
                {
                    if(enumSide==SIDE.Mid)
                    { 
                        NewXPos=ZPos;
                        enumSide=SIDE.Right;
                    }
                    else if(enumSide==SIDE.Left)
                    {
                        NewXPos=0;
                        enumSide=SIDE.Mid;
                    }
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    // outputText.text = "Right";
                    if(enumSide==SIDE.Mid)
                    {
                        NewXPos= -ZPos;
                        enumSide=SIDE.Left;
                    }
                    else if(enumSide==SIDE.Right)
                    {
                        NewXPos=0;
                        enumSide=SIDE.Mid;
                    }
                    stopTouch = true;
                }
                else if (Distance.y > jumpRange)
                {
                    // outputText.text = "Up";
                    if(isGrounded)
                    {
                        AndroidJump();
                        stopTouch = true;
                    }
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;
        }

    }
    private void AndroidJump()
    {
        isGrounded=false;
        animator.SetTrigger("isJumping");
        _rigidBody.AddForce(Vector3.up*jumpHeight*2,ForceMode.VelocityChange);
        StartCoroutine(WaitAfterJump());
    }
    IEnumerator WaitAfterJump()
    {
        yield return new WaitForSeconds(1f);
        isJumping=false;
    }
    private void MovePlayer()
    {
        transform.Translate((NewXPos-transform.position.z)*Vector3.forward*Time.deltaTime*sidescrollSpeed,Space.World);
        transform.Translate(Vector3.right*Time.deltaTime*moveSpeed,Space.World);
        if(transform.position.x>distanceToIncreaseSpeed && !PauseMenu.activeSelf)
        {
            if(moveSpeed<maxSpeedToIncrease)
                moveSpeed+=speedIncreaser;
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded=true;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            if(CoinSoundEffect!=null)
                CoinSoundEffect.Play();
            if(CollectEffect.isPlaying)
                CollectEffect.Stop();
            if(CollectEffect!=null)
                CollectEffect.Play();
        }    
    }
    private void StandAloneInput()
    {
             swiptRight=Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
             swiptLeft=Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
             if(swiptRight)
             {
                 if(enumSide==SIDE.Mid)
                 {
                     NewXPos= -ZPos;
                     enumSide=SIDE.Left;
                 }
                 else if(enumSide==SIDE.Right)
                 {
                     NewXPos=0;
                     enumSide=SIDE.Mid;
                 }
             }
             else if(swiptLeft)
             {
                 if(enumSide==SIDE.Mid)
                 { 
                     NewXPos=ZPos;
                     enumSide=SIDE.Right;
                 }
                 else if(enumSide==SIDE.Left)
                 {
                     NewXPos=0;
                     enumSide=SIDE.Mid;
                 }
             }
    }

}

