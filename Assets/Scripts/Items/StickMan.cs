using System.Linq;
using Core;
using UnityEngine;
using Zenject;

namespace Items
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class StickMan : CollidingItem
    {
        private AppCore _core;
        private Rigidbody[] _rigidbodies;
        private Collider[] _colliders;

        private Rigidbody _parentRigidbody;
        private Collider _parentCollider;
        private Animator _animator;

        [Inject]
        public void Construct(AppCore core)
        {
            _core = core;
            _rigidbodies = GetComponentsInChildren<Rigidbody>()
                .Where(g => g.gameObject != gameObject)
                .ToArray();

            _colliders = GetComponentsInChildren<Collider>()
                .Where(g => g.gameObject != gameObject)
                .ToArray();

            _parentCollider = GetComponent<Collider>();
            _parentRigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            
            EnableRagdoll(false);
        }

        private void EnableRagdoll(bool state)
        {
            _parentCollider.enabled = !state;
            _parentRigidbody.isKinematic = state;
            _animator.enabled = !state;
            
            foreach (Rigidbody rigidbody in _rigidbodies)
                rigidbody.isKinematic = !state;

            foreach (Collider collider in _colliders)
                collider.enabled = state;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall _))
            {
                _core.UpdateState(AppState.Lose);
                EnableRagdoll(true);
            }
        }
    }
}