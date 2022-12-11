using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private bool _detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float _minDistanceForSwipe = 20f;
    private Vector2 _fingerUpPosition;
    private Vector2 _fingerDownPosition;
    public static event Action<SwipeData> OnSwipe = delegate { };

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _fingerUpPosition = touch.position;
                _fingerDownPosition = touch.position;
            }

            if (!_detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                _fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = _fingerDownPosition.y - _fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = _fingerDownPosition.x - _fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
            _fingerUpPosition = _fingerDownPosition;
        }
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = _fingerDownPosition,
            EndPosition = _fingerUpPosition
        };
        OnSwipe(swipeData);
    }

    private bool IsVerticalSwipe()
    {
        return VerticaMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticaMovementDistance() > _minDistanceForSwipe || HorizontalMovementDistance() > _minDistanceForSwipe;
    }

    private float VerticaMovementDistance()
    {
        return Mathf.Abs(_fingerDownPosition.y - _fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(_fingerDownPosition.x - _fingerUpPosition.x);
    }

    public struct SwipeData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public SwipeDirection Direction;
    }

    public enum SwipeDirection
    {
        Down,
        Up,
        Left,
        Right
    }
}
