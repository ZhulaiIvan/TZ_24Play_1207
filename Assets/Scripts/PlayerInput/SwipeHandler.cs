using System;
using UnityEngine;

namespace PlayerInput
{
    public class SwipeHandler : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 3f; // TODO: settings screen
        
        private Vector2 _touchStartPosition;
        public Action<Direction, float> OnSwiped { get; set; }

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
                    
                    Debug.Log($"Swipe direction: {swipeDirection.x}");
                    OnSwiped?.Invoke(swipeDirection.x > 0 ? Direction.Right : Direction.Left, _sensitivity);

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