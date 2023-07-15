using System;
using System.Linq;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Items
{
    [RequireComponent(typeof(Rigidbody))]
    public class StickMan : CollidingItem
    {
        private AppCore _core;
        private Rigidbody[] _rigidbodies;
        private Collider[] _colliders;

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

            DisableRagdoll();
        }

        private void DisableRagdoll()
        {
            foreach (Rigidbody rigidbody in _rigidbodies)
                rigidbody.isKinematic = true;

            foreach (Collider collider in _colliders)
                collider.enabled = false;
        }

        private void EnableRagdoll()
        {
            foreach (Rigidbody rigidbody in _rigidbodies)
                rigidbody.isKinematic = false;

            foreach (Collider collider in _colliders)
                collider.enabled = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall _))
            {
                _core.UpdateState(AppState.Lose);
                EnableRagdoll();
            }
        }
    }
}