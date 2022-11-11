using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private GameObject _cube;
    [SerializeField] private Rigidbody rigidbody;

    void FixedUpdate()
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

    void Move()
    {    
        rigidbody.AddForce((new Vector3(0, 0, 1)) * _startSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    void Stop()
    {
        if (rigidbody.velocity.magnitude > 1)
        {
            rigidbody.AddForce((new Vector3(0, 0, -1)) * (rigidbody.velocity.magnitude - 0.1f) * Time.deltaTime, ForceMode.Impulse);
        }
        else 
            rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Gate")
        {
            ScoreManager.ScoreCount += 10;
            ScoreManager.Multiplier++;
            if (rigidbody.velocity.magnitude < 2)
            {
                ScoreManager.ScoreCount = -5;
                ScoreManager.Multiplier = 1;
            }
        }
    }
}
