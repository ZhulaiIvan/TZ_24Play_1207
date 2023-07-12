using System;
using UnityEngine;

namespace PlayerInput
{
    public class SwipeHandler : MonoBehaviour
    {
        private Vector2 _touchStartPosition;
        public Action<Direction> OnSwipped { get; set; }

        private void Update()
        {
            if (Input.touchCount <= 0) return;

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 swipeDirection = touch.position - _touchStartPosition;
                    swipeDirection.Normalize();

                    OnSwipped?.Invoke(swipeDirection.x > 0 ? Direction.Right : Direction.Left);

                    _touchStartPosition = touch.position;
                    break;
            }
        }
    }

    public enum Direction
    {
        Left,
        Right,
        None
    }
}