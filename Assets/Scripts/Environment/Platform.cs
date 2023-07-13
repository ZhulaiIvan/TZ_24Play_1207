using System;
using UnityEngine;

namespace Environment
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float _moveSpeed;

        private Vector3 _targetPosition = default;
        private bool _isMoving;
        private PlatformTriggerZone _triggerZone;
        public Vector3 MaxPosition => _renderer.bounds.max;

        public PlatformTriggerZone TriggerZone
        {
            get
            {
                if (_triggerZone == null)
                    throw new Exception("Platform don't have trigger zone!");

                return _triggerZone;
            }
        }

        public void SetTargetPosition(Vector3 targetPos)
        {
            _isMoving = true;
            _targetPosition = targetPos;
        }

        private void OnEnable()
        {
            _triggerZone = GetComponentInChildren<PlatformTriggerZone>();
        }

        private void Update()
        {
            _isMoving = Vector3.Distance(transform.position, _targetPosition) > 0.001f;

            if (_isMoving && _targetPosition != default)
                transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }
}