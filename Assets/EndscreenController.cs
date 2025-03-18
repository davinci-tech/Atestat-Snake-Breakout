using UnityEngine;
using UnityEngine.SceneManagement;

public class EndscreenController : MonoBehaviour
{
    private bool _hidden = true;
    public GameObject endscreen;

    public void Awake()
    {
        endscreen.SetActive(!_hidden);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
            // _hidden = !_hidden;
            // endscreen.SetActive(!_hidden);
            // Time.timeScale = _hidden ? 1 : 0;
        }
    }

    public void Resume()
    {
        _hidden = true;
        Debug.Log("Resume pressed");
    }

    public void Exit()
    {
        _hidden = true;
        SceneActions.OpenMainScreen();
    }
}
