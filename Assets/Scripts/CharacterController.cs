using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector3 dir;
    //[SerializeField] private Transform startPosition;
    [SerializeField] private float _startSpeed;
    [SerializeField] private GameObject _cube;
    private float _speed;
    [SerializeField] private Rigidbody rigidbody;

    void Start()
    {
        //_speed = _startSpeed;
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude < 10)
        Move();
    }

    void Move()
    {    
        rigidbody.AddForce((new Vector3(0, 0, 1)) * _startSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
