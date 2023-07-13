using System;
using Player;
using UnityEngine;

namespace Items
{
    public class Pickup : Colliding
    {
        private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody;
        public event Action<Pickup> OnPickupTriggered;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Pickup pickup)) return;
            
            other.isTrigger = false;
            _rigidbody.useGravity = false;
            OnPickupTriggered?.Invoke(pickup);
        }
    }
}