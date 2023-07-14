using System;
using System.Collections;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class PlayerCube : MonoBehaviour
    {
        public Action OnPickupTriggered;
        public Action<PlayerCube> OnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall wall) &&
                Math.Abs(transform.position.y - wall.transform.position.y) < 1f
                && Math.Abs(transform.position.x - wall.transform.position.x) < 1f)
            {
                OnCollision?.Invoke(this);
                StartCoroutine(DestroyCube());
            }
        }

        private IEnumerator DestroyCube()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Pickup pickup)
                && Math.Abs(transform.position.y - pickup.transform.position.y) < 0.5f)
            {
                Destroy(pickup.gameObject);
                OnPickupTriggered?.Invoke();
            }
        }
    }
}