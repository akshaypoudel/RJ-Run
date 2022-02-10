using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    public AudioSource DeathAudio;
    // [SerializeField]private float deathChangePosTime;
    public GameObject GameOverPanel;
    [SerializeField]private float waitBeforeDeath=1.9f;
    [SerializeField]private float waitAfterDeath=1.2f;
    [SerializeField]private float deathXPos=0.2f;
    [SerializeField]private int colliderDirection=2;
    [SerializeField]private float deathYPos = -0.206f;
    private void Start() {
        animator=GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Car"))
        {
            StartCoroutine(ReloadGame());
        }
    }
    IEnumerator ReloadGame()
    {
        if(DeathAudio!=null)
            DeathAudio.Play();
        this.gameObject.GetComponent<PlayerController>().enabled=false;
        // Debug.Log("GameOver: ");
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(waitBeforeDeath);
        this.gameObject.GetComponent<CapsuleCollider>().direction=colliderDirection;
        this.gameObject.transform.position=new Vector3(transform.position.x-deathXPos,deathYPos,transform.position.z);
        yield return new WaitForSeconds(waitAfterDeath);
        GameOverPanel.SetActive(true);
        CoinScript.coins=0;
    }
}


