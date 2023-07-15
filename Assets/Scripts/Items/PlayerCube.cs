using System;
using System.Collections;
using Environment;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class PlayerCube : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailPrefab;

        public Action OnPickupTriggered;
        public Action<PlayerCube> OnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall wall) &&
                Math.Abs(transform.position.y - wall.transform.position.y) < 1f
                && Math.Abs(transform.position.x - wall.transform.position.x) < 0.8f)
            {
                OnCollision?.Invoke(this);
               // StartCoroutine(DestroyCube());
               transform.SetParent(wall.transform);
                return;
            }

            if (collision.gameObject.TryGetComponent(out Platform _)) 
                Instantiate(_trailPrefab, transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Pickup pickup)
                || !(Math.Abs(transform.position.y - pickup.transform.position.y) < 0.5f)) return;
            
            Destroy(pickup.gameObject);
            OnPickupTriggered?.Invoke();
        }
    }
}