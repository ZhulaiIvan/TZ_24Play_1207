using System;
using Core;
using UnityEngine;

namespace Player
{
    public class SwipeHandler : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 3f; // TODO: settings screen
        
        private Vector2 _touchStartPosition;
        private AppState _currentState;
        public Action<Direction, float> OnSwiped { get; set; }

        private void Update()
        {
            if (Input.touchCount <= 0 || _currentState == AppState.Game) return;

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 swipeDirection = touch.position - _touchStartPosition;
                    swipeDirection.Normalize();
                    
                    OnSwiped?.Invoke(swipeDirection.x > 0 ? Direction.Right : Direction.Left, _sensitivity);

                    _touchStartPosition = touch.position;
                    break;
            }
        }

        public void SetState(AppState state)
        {
            _currentState = state;
        }
    }

    public enum Direction
    {
        Left,
        Right,
        None
    }
}