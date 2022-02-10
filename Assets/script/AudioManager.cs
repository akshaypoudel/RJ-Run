using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private float BGSFX,playSFX;
    private GameObject BGMusic;
    public AudioSource BackGroundAudio;
    public AudioSource[] SoundEffects;
    private void Awake() {
        if(BackGroundAudio==null)
        {
            BGMusic=GameObject.FindWithTag("Audio");
            BackGroundAudio=BGMusic.GetComponent<AudioSource>();
        }
        PlaySFX();
    }
    private void PlaySFX()
    {
        BGSFX=PlayerPrefs.GetFloat("BackGroundAudio");
        playSFX=PlayerPrefs.GetFloat("SFXAudio");

        BackGroundAudio.volume=BGSFX;
        
        for(int f=0;f<SoundEffects.Length;f++)
        {
            SoundEffects[f].volume=playSFX;
        }
    }

}
