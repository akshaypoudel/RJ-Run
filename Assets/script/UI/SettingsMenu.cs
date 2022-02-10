using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsMenu : MonoBehaviour
{
    #region References
    public Slider backgroundSlider;
    public GameObject PlayButton;
    public Slider SFXSlider;
    public GameObject donut_light;
    public GameObject Player;
    public GameObject MainMenuButton;
    public GameObject DropDownValue;
    public AudioSource BackGroundAudio;
    private GameObject BGMusicAudio;
    public AudioSource[] SoundEffects;
    #endregion
    private void Awake() {
        if(BackGroundAudio==null)
        {
            BGMusicAudio=GameObject.FindWithTag("Audio");
            BackGroundAudio=BGMusicAudio.GetComponent<AudioSource>();
        }
        
    }
    private void Start() {
        if(!PlayerPrefs.HasKey("QualityIndex"))
        {
            PlayerPrefs.SetInt("QualityIndex",1);
            GraphicsSettingsLoad();
        }
        else
        {
            GraphicsSettingsLoad();
        }


        if(!PlayerPrefs.HasKey("BackGroundAudio"))
        {
            PlayerPrefs.SetFloat("BackGroundAudio",1);
            LoadBackGroundAudio();
        }
        else
        {
            LoadBackGroundAudio();
        }


        if(!PlayerPrefs.HasKey("SFXAudio"))
        {
            PlayerPrefs.SetFloat("SFXAudio",1);
            LoadSFXAudio();
        }
        else
        {
            LoadSFXAudio();
        }
    
    }

    #region AUDIO
    // VOLUME FUNCTIONS
        #region BackGroundAudios
            public void SetBackGroundAudio()
            {
                BackGroundAudio.volume=backgroundSlider.value;
                SaveBackGroundAudio();
            }
            public void SaveBackGroundAudio()
            {
                PlayerPrefs.SetFloat("BackGroundAudio",backgroundSlider.value);
            }
            private void LoadBackGroundAudio()
            {
                backgroundSlider.value=PlayerPrefs.GetFloat("BackGroundAudio");
                BackGroundAudio.volume=PlayerPrefs.GetFloat("BackGroundAudio");
            }

        #endregion
        
        #region SFXAudio
            public void SetSFXAudio()
            {
                for(int i=0;i<SoundEffects.Length;i++)
                {
                    SoundEffects[i].volume=SFXSlider.value;
                }
                SaveSFXAudio();
            }
            public void SaveSFXAudio()
            {
                PlayerPrefs.SetFloat("SFXAudio",SFXSlider.value);
                Debug.Log("Playerprfs SAVE: "+PlayerPrefs.GetFloat("SFXAudio"));
            }
            public void LoadSFXAudio()
            {
                for (int i = 0; i < SoundEffects.Length; i++)
                {
                    SoundEffects[i].volume=SFXSlider.value;
                }
                SFXSlider.value=PlayerPrefs.GetFloat("SFXAudio");
                Debug.Log("Playerprefs LOAD: "+PlayerPrefs.GetFloat("SFXAudio"));
            }

        #endregion
    
    #endregion
    //QUALITY FUNCTIONS 
    #region QualitySettings
        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            GraphicsSettingsSave(qualityIndex);
        }
        public void GraphicsSettingsSave(int index)
        {
            PlayerPrefs.SetInt("QualityIndex",index);
        }
        private void GraphicsSettingsLoad()
        {
            DropDownValue.GetComponent<TMP_Dropdown>().value=PlayerPrefs.GetInt("QualityIndex");    
        }

    #endregion


//Disable And Enable Backgrounds Functions
    public void DisableBackGround()
    {
        PlayButton.GetComponent<Button>().enabled=false;
        MainMenuButton.GetComponent<Button>().enabled=false;
        Player.GetComponent<TouchRotation>().enabled=false;
        donut_light.SetActive(false);
    }
    public void EnableBackGround()
    {
        PlayButton.GetComponent<Button>().enabled=true;
        MainMenuButton.GetComponent<Button>().enabled=true;
        Player.GetComponent<TouchRotation>().enabled=true;
        donut_light.SetActive(true);
    }

}
