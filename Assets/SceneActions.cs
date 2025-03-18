using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActions : MonoBehaviour
{
    static public void OpenSnakeScene()
    {
        SceneManager.LoadScene("Scenes/Snake");
    }

    static public void OpenBreakoutScene()
    {
        SceneManager.LoadScene("Scenes/Breakout");
    }

    static public void OpenMainScreen()
    {
        SceneManager.LoadScene("Scenes/Main Screen");
    }
}
