using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private Transform Player;
    public static int coins=0;
    public static int donut=0;
    // public ParticleSystem coinCollectEffect;
    public float rotateSpeed;
    // private AudioSource CoinSoundEffect;
    private Text CoinText;
    private void Start() {
        // coins=0;
        // coinCollectInfo=GetComponent<ParticleSystem>();
        Player=GameObject.Find("Player").transform;
        CoinText=GameObject.Find("coinText").GetComponent<Text>();
        // CoinSoundEffect=GameObject.Find("DonutSFX").GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("Donut"))
        {
            donut=PlayerPrefs.GetInt("Donut");
        }
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up*rotateSpeed,Space.World);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player")
        {

            // coinCollectEffect.Play();
            ++coins;
            ++donut;
            PlayerPrefs.SetInt("Donut",donut);
            CoinText.text=coins.ToString();
            Destroy(this.gameObject);
        }
    }
}
