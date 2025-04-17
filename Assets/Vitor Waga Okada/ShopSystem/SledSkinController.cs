using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SledSkinController : MonoBehaviour
{
    public static SledSkinController Instance;
    [SerializeField] Sprite skin0;
    [SerializeField] Sprite skin1;

    //For currentSkin, skin0 is 0, skin1 is 1, etc.
    public static int currentSkin;

    void Awake()
    {
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
        if (SceneManager.GetActiveScene().name == "GameDemo") {
            Debug.Log("In GameDemo!");
            changeSkin();
        }
    }

    public void changeSkin() {
        SpriteRenderer currentSledSpriteRenderer = GameObject.Find("Sled").GetComponent<SpriteRenderer>();

        if (currentSkin == 0) {
            Debug.Log("Setting Skin 0");
            currentSledSpriteRenderer.sprite = skin0;
            Debug.Log(currentSledSpriteRenderer.sprite.name);
        }

        if (currentSkin == 1) {
            Debug.Log("Setting Skin 1");
            currentSledSpriteRenderer.sprite = skin1;
            Debug.Log(currentSledSpriteRenderer.sprite.name);
        }
    }
}
