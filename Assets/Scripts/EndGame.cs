using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private static bool _isEnd = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
            ScoreManager.ScoreCount += 100;
            _isEnd = true;
        }
    }

    public static bool IsEnd
    {
        get { return _isEnd; }
        set { _isEnd = value; }
    }
}
