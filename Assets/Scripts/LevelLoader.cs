using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("GameDemo");
    }
}
