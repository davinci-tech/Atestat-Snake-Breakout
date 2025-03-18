using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeTimeManager : MonoBehaviour
{
    private bool _spawnedDagger = false;
    private float _timeLeft; // in seconds
    public TMP_Text timeText;
    public Transform daggerPrefab;

    public void Awake()
    {
        _timeLeft = Constants.Snake.timelimit;
    }

    public void Update()
    {
        // update the time
        _timeLeft = Math.Clamp(_timeLeft - Time.deltaTime, 0, float.PositiveInfinity);
        timeText.text = _timeLeft.ToString("F3");

        // spawn logic for dagger (this should be separated into a separate file, but since
        // the codebase is pretty small it works for now)
        if (_timeLeft <= Constants.Snake.daggerSpawnTreshold && !_spawnedDagger)
        {
            Instantiate(daggerPrefab).GetComponent<DaggerItemController>().ChangePosition();
            _spawnedDagger = true;
        }

        // logic for resetting the scene when the time reaches 0
        if (_timeLeft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AteDagger()
    {
        _timeLeft += Constants.Snake.timelimit;
    }
}
