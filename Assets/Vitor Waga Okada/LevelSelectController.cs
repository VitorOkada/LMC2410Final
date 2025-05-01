using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    public void goToLevel1() {
        SceneManager.LoadScene("GameDemo");
    }

    public void goToLevel2() {
        SceneManager.LoadScene("Jake's Level");
    }

    public void goToTitle() {
        SceneManager.LoadScene("MenuScene");
    }
}
