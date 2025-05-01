using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour
{
    // Start is called before the first frame update

    public void goToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }
}
