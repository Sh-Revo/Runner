using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeDetector;

public class SwipeManager : MonoBehaviour
{
    [SerializeField] private GameObject _partToRotate;
    [SerializeField] private Rigidbody _characterRigidbody;
    private SwipeDirection _direction;
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        _direction = data.Direction;
    }

    private void Update()
    {
        if (EndGame.IsEnd == false)
        {
            if (_direction == SwipeDirection.Right)
            {
                _partToRotate.transform.rotation = Quaternion.Euler(0, _partToRotate.transform.rotation.eulerAngles.y + 90f, 0);
                _direction = 0;
            }
            if (_direction == SwipeDirection.Left)
            {
                _partToRotate.transform.rotation = Quaternion.Euler(0, _partToRotate.transform.rotation.eulerAngles.y - 90f, 0);
                _direction = 0;
            }
            if (_direction == SwipeDirection.Up)
            {
                if (_characterRigidbody.velocity.magnitude < CharacterController.StartSpeed + 5f)
                {
                    _characterRigidbody.AddForce((new Vector3(0, 0, 1)) * (CharacterController.StartSpeed + 10) * Time.deltaTime, ForceMode.Impulse);
                    if (_characterRigidbody.velocity.magnitude > CharacterController.StartSpeed + 5f)
                    {
                        _direction = 0;
                    }
                }
                ScoreManager.SpeedBonus = 2;
            }
            if (_direction == SwipeDirection.Down)
            {
                if (_characterRigidbody.velocity.magnitude > CharacterController.StartSpeed)
                {
                    _characterRigidbody.AddForce((new Vector3(0, 0, -1)) * (CharacterController.StartSpeed + 35) * Time.deltaTime, ForceMode.Impulse);
                    if (_characterRigidbody.velocity.magnitude < CharacterController.StartSpeed)
                    {
                        _direction = 0;
                    }
                }
                ScoreManager.SpeedBonus = 1;
            }
        }
        else
        {
            _direction = 0;
        }
    }
}
