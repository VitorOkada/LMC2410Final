using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SledSkinController : MonoBehaviour
{
    public static SledSkinController Instance;

    AudioSource music;
    [SerializeField] AudioClip TitleMusic;
    [SerializeField] AudioClip Level1Music;
    [SerializeField] AudioClip Level2Music;
    bool changedToTitleMusic;
    bool changedToLevel1Music;
    bool changedToLevel2Music;
    [SerializeField] Sprite skin0;
    [SerializeField] Sprite skin1;
    [SerializeField] Sprite skin2;

    public static bool item2Bought;
    public static bool item3Bought;

    //For currentSkin, skin0 is 0, skin1 is 1, etc.
    public static int currentSkin;

    void Awake()
    {
        changedToTitleMusic = false;
        changedToLevel1Music = false;
        changedToLevel2Music = false;
        music = GetComponent<AudioSource>();
        if (Instance != null) {
            Destroy(gameObject);
        }

        Instance = this;

        if (SceneManager.GetActiveScene().name == "MenuScene") {
            currentSkin = 0;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Debug.Log(currentSkin);
        if (SceneManager.GetActiveScene().name == "MenuScene" || SceneManager.GetActiveScene().name == "LevelSelect" || SceneManager.GetActiveScene().name == "WinScene") {
            if (changedToTitleMusic == false) {
                music.volume = 0.65f;
                music.clip = TitleMusic;
                music.Play();
                changedToTitleMusic = true;
                changedToLevel1Music = false;
                changedToLevel2Music = false;
            }
        }

        if (SceneManager.GetActiveScene().name == "GameDemo") {
            if (changedToLevel1Music == false) {
                music.volume = 0.5f;
                music.clip = Level1Music;
                music.Play();
                changeSkin();
                changedToTitleMusic = false;
                changedToLevel1Music = true;
                changedToLevel2Music = false;
            }
        }

        if (SceneManager.GetActiveScene().name == "Jake's Level") {
            if (changedToLevel2Music == false) {
                Debug.Log("Playing Level 2 music");
                music.volume = 0.5f;
                music.clip = Level2Music;
                music.Play();
                changeSkin();
                changedToTitleMusic = false;
                changedToLevel1Music = false;
                changedToLevel2Music = true;
            }
        }
    }

    public void changeSkin() {
        SpriteRenderer currentSledSpriteRenderer = GameObject.Find("Sled").GetComponent<SpriteRenderer>();

        if (currentSkin == 0) {
            //Debug.Log("Setting Skin 0");
            currentSledSpriteRenderer.sprite = skin0;
            //Debug.Log(currentSledSpriteRenderer.sprite.name);
        }

        if (currentSkin == 1) {
            //Debug.Log("Setting Skin 1");
            currentSledSpriteRenderer.sprite = skin1;
            //Debug.Log(currentSledSpriteRenderer.sprite.name);
        }

        if (currentSkin == 2) {
            currentSledSpriteRenderer.sprite = skin2;
        }
    }

    public void boughtSkin2() {
        item2Bought = true;
    }

    public void boughtSkin3() {
        item3Bought = true;
    }
}
