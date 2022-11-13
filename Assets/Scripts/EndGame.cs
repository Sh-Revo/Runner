using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    private static bool _isEnd = false;
    [SerializeField] private ParticleSystem _speedBoostEffect;
    [SerializeField] private Text scoreText;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
            ScoreManager.ScoreCount += 100;
            _speedBoostEffect.Stop();
            _isEnd = true;
            scoreText.text = ScoreManager.ScoreCount.ToString();
        }
    }

    public static bool IsEnd
    {
        get { return _isEnd; }
        set { _isEnd = value; }
    }
}
