using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeDetector;

public class SwipeManager : MonoBehaviour
{
    [SerializeField] private GameObject _partToRotate;
    [SerializeField] private Rigidbody _characterRigidbody;
    [SerializeField] private ParticleSystem _speedBoostEffect;
    private SwipeDirection _direction;
    private float _bonusSpeed = 10f;
    private int _bonusSpeedMultiplier = 2;
    private float _angle = 90f;

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
        _speedBoostEffect.Stop();
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
                _partToRotate.transform.rotation = Quaternion.Euler(0, _partToRotate.transform.rotation.eulerAngles.y + _angle, 0);
                _direction = 0;
            }
            if (_direction == SwipeDirection.Left)
            {
                _partToRotate.transform.rotation = Quaternion.Euler(0, _partToRotate.transform.rotation.eulerAngles.y - _angle, 0);
                _direction = 0;
            }
            if (_direction == SwipeDirection.Up)
            {
                if (_characterRigidbody.velocity.magnitude < CharacterController.StartSpeed + _bonusSpeed)
                {
                    _characterRigidbody.AddForce((new Vector3(0, 0, 1)) * (CharacterController.StartSpeed + _bonusSpeed) * Time.deltaTime, ForceMode.Impulse);
                    _speedBoostEffect.Play();
                    if (_characterRigidbody.velocity.magnitude > CharacterController.StartSpeed + _bonusSpeed)
                    {
                        _direction = 0;
                    }
                }
                ScoreManager.SpeedBonus = _bonusSpeedMultiplier;
            }
            if (_direction == SwipeDirection.Down)
            {
                if (_characterRigidbody.velocity.magnitude > CharacterController.StartSpeed)
                {
                    _characterRigidbody.AddForce((new Vector3(0, 0, -1)) * (CharacterController.StartSpeed + _bonusSpeed) * Time.deltaTime, ForceMode.Impulse);
                    _speedBoostEffect.Stop();
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
