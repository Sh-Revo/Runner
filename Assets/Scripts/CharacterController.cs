using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private static int _startSpeed = 10;
    private new Rigidbody rigidbody;
    private int _gateScore = 10;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (EndGame.IsEnd == false)
        {
            if (rigidbody.velocity.magnitude < _startSpeed)
                Move();
        }
        else
        {
            Stop();
        }
    }

    private void Move()
    {    
        rigidbody.AddForce((new Vector3(0, 0, 1)) * _startSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    private void Stop()
    {
        if (rigidbody.velocity.magnitude > 1)
        {
            rigidbody.AddForce((new Vector3(0, 0, -1)) * (rigidbody.velocity.magnitude - rigidbody.velocity.magnitude / 10f) * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }          
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Gate")
        {
            ScoreManager.ScoreCount += _gateScore;
            ScoreManager.Multiplier++;
            if (rigidbody.velocity.magnitude < 2)
            {
                ScoreManager.ScoreCount -= _gateScore * 2;
                ScoreManager.Multiplier = 1;
            }
        }
    }

    public static int StartSpeed
    {
        get { return _startSpeed; }
        set { _startSpeed = value; }
    }
}
