using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject _scoreDisplay;
    private static int _startScoreCount = 0;
    private static int _scoreCount;
    private static int _multiplier = 1;
    private static int _speedBonus = 1;
    private bool _addScore = false;
    private float _scoreDelay = 0.5f;

    private void Start()
    {
        ScoreCount = _startScoreCount;
        Multiplier = _multiplier;
    }

    void Update()
    {
        if (Multiplier < 1)
            Multiplier = 1;
        if (EndGame.IsEnd == false)
        {
            if (_addScore == false)
            {
                _addScore = true;
                StartCoroutine(AddingScore());
            }
        }
        else
            _scoreDisplay.GetComponent<Text>().text = " " + _scoreCount;
    }

    IEnumerator AddingScore()
    {
        ScoreCount += Multiplier * SpeedBonus;
        _scoreDisplay.GetComponent<Text>().text = " " + _scoreCount;
        yield return new WaitForSeconds(_scoreDelay);
        _addScore = false;
    }

    public static int ScoreCount
    {
        get { return _scoreCount; }
        set { _scoreCount = value; }
    }

    public static int Multiplier
    {
        get { return _multiplier; }
        set { _multiplier = value; }
    }

    public static int SpeedBonus
    {
        get { return _speedBonus; }
        set { _speedBonus = value; }
    }
}
