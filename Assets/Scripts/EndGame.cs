using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private ParticleSystem _speedBoostEffect;
    [SerializeField] private Text scoreText;
    private static bool _isEnd;
    private int _endScoreBonus = 100;

    private void Start()
    {
        _isEnd = false;
    }

    private void Update()
    {
        End();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
            ScoreManager.ScoreCount += _endScoreBonus;
            _isEnd = true;
        }
    }

    private void End()
    {
        if (_isEnd)
        {
            _speedBoostEffect.Stop();
            scoreText.text = ScoreManager.ScoreCount.ToString();
        }
    }

    public static bool IsEnd
    {
        get { return _isEnd; }
        set { _isEnd = value; }
    }
}
