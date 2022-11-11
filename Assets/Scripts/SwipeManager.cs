using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeDetector;

public class SwipeManager : MonoBehaviour
{
    [SerializeField] private GameObject partToRotate;
    private SwipeDirection _direction;
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        //partToRotate.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), Time.deltaTime);
        Debug.Log("Swipe in Deirection: " + data.Direction);
        _direction = data.Direction;
    }

    private void Update()
    {
        if (_direction == SwipeDirection.Right)
        {
            //Quaternion target = Quaternion.Euler(0, 90f, 0);
            //partToRotate.transform.rotation = Quaternion.RotateTowards(partToRotate.transform.rotation, target, 100f * Time.deltaTime);
            //partToRotate.transform.rotation = Quaternion.Lerp(partToRotate.transform.rotation, target, 10f * Time.deltaTime);
            partToRotate.transform.rotation = Quaternion.Euler(0, partToRotate.transform.rotation.eulerAngles.y + 90f, 0);
            _direction = 0;
        }
        if (_direction == SwipeDirection.Left)
        {
            partToRotate.transform.rotation = Quaternion.Euler(0, partToRotate.transform.rotation.eulerAngles.y - 90f, 0);
            _direction = 0;
        }
    }
}
