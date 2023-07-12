using System;
using Environment;
using PlayerInput;
using UnityEngine;
using Zenject;

namespace Items
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public abstract class Movable : MonoBehaviour
    {
        [SerializeField] private float _speed =7f;

        private Rigidbody _rigidbody;
        private SwipeHandler _swipeHandler;
        private float _maxX;
        private float _minX;
        private float _swipeForce;

        [Inject]
        public void Construct(SwipeHandler swipeHandler, MovementLimits limits)
        {
            _swipeHandler = swipeHandler;
            _swipeHandler.OnSwiped += Swiped;
            _maxX = limits.MaxX - transform.localScale.x / 2;
            _minX = limits.MinX + transform.localScale.x / 2;
        }

        private void Swiped(Direction direction)
        {
            _swipeForce = direction == Direction.Left ? -_speed : _speed;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_swipeForce * Vector3.right, ForceMode.VelocityChange);
            _rigidbody.velocity = Vector3.forward * _speed;
        }

        private void Update()
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, _minX, _maxX),
                transform.position.y,
                transform.position.z);
        }

        private void OnDestroy()
        {
            _swipeHandler.OnSwiped -= Swiped;
        }
    }
}