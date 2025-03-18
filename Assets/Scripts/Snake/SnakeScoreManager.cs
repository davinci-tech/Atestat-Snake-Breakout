using System;
using TMPro;
using UnityEngine;

// https://colorhunt.co/palette/f7f7f7ffb22c854836000000

public class SnakeScoreManager : MonoBehaviour
{
    private float _score = SnakeController.initialLength + 1;
    private float _highscore;
    private float _multiplier = 1f;
    private bool _spawnedFirstEnergizer = false;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Transform energizerPrefab;

    public void Awake()
    {
        _highscore = PlayerPrefs.GetFloat("Snake/Highscore", _score);
    }

    public void AteFood()
    {
        _score += _multiplier;
    }

    public void AteEnergizer()
    {
        _multiplier += 2f;
    }

    public void AteDagger()
    {
        _score = Mathf.Floor(_score / 2);
    }

    public void Update()
    {
        _highscore = Math.Max(_highscore, _score);
        scoreText.text = _score.ToString("0.###");
        highScoreText.text = _highscore.ToString("0.###");

        // initial spawn logic for energizers... this should be separated into another file,
        // but given how simple the project is it works for now
        if (_score >= Constants.Snake.initialEnergizerRequirement && _spawnedFirstEnergizer == false)
        {
            Instantiate(energizerPrefab).GetComponent<EnergizerItemController>().ChangePosition();
            _spawnedFirstEnergizer = true;
        }
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetFloat("Snake/Highscore", _highscore);
        PlayerPrefs.Save();
    }

    public float Score => _score;
}
