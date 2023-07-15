using Cinemachine;
using Core;
using Environment;
using UnityEngine;
using Zenject;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _speed = 7f;
        [SerializeField] private CinemachineFreeLook _camera;
        [SerializeField] private Transform _stickMan;
        
        private CharacterController _controller;
        private SwipeHandler _swipeHandler;
        private float _minX;
        private float _maxX;
        private float _currentSpeed;
        
        [Inject]
        public void Construct(SwipeHandler swipeHandler, MovementLimits limits)
        {
            _swipeHandler = swipeHandler;
            _swipeHandler.OnSwiped += Swiped;

            _minX = limits.MinX + transform.localScale.x / 2;
            _maxX = limits.MaxX - transform.localScale.x / 2;
        }

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            _controller.Move(Vector3.forward * _currentSpeed * Time.deltaTime);
        }

        private void Swiped(Direction direction, float sensitivity)
        {
            if (direction == Direction.Left && transform.position.x <= _minX ||
                direction == Direction.Right && transform.position.x >= _maxX) return;
        
            float force = direction == Direction.Left ? -sensitivity : sensitivity;
            _controller.Move(force * Vector3.right * Time.deltaTime);
        }

        public void SetState(AppState state)
        {
            switch (state)
            {
                case AppState.Menu:
                    _currentSpeed = 0f;
                    break;
                case AppState.Game:
                    _camera.Follow = _stickMan;
                    _currentSpeed = _speed;
                    break;
                case AppState.Lose:
                    _camera.Follow = null;
                    _currentSpeed = 0f;
                    break;
                default:
                    break;
            }
        }
    }
}
