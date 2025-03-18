using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakoutGameManager : MonoBehaviour
{
    private float _time = 0;
    private float _bestTime = 0;
    private int _ballsCount;
    private WallController _wallController;
    private int _brickCount;
    public TMP_Text bestTimeText;
    public TMP_Text timeText;

    public void Awake()
    {
        _ballsCount = 1;
        _bestTime = PlayerPrefs.GetFloat("Breakout/BestTime", float.MaxValue);
        _wallController = GameObject.FindGameObjectWithTag("Breakout/Wall").GetComponent<WallController>();
        _brickCount = _wallController.BrickCount();
    }

    public void Update()
    {
        _time += Time.deltaTime;

        timeText.text = _time.ToString("F3");
        bestTimeText.text = _bestTime == float.MaxValue ? "-" : _bestTime.ToString("F3");

        if (_brickCount <= 0) Die(true);
        if (_ballsCount <= 0) Die(false);
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetFloat("Breakout/BestTime", _bestTime);
        PlayerPrefs.Save();
    }

    public void DestroyedBrick()
    {
        _brickCount -= 1;
    }

    public void DestroyedBall()
    {
        _ballsCount -= 1;
    }

    public void CreatedBall()
    {
        _ballsCount += 1;
    }

    public void Die(bool finishedGame)
    {
        if (finishedGame)
        {
            _bestTime = Math.Min(_bestTime, _time);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
