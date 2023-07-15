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
                && Math.Abs(transform.position.x - wall.transform.position.x) < 0.5f)
            {
                OnCollision?.Invoke(this);
                StartCoroutine(DestroyCube());
            }
            
            if (collision.gameObject.TryGetComponent(out Platform _))
            {
                TrailRenderer trailRenderer = Instantiate(_trailPrefab, transform);
                trailRenderer.transform.position = new Vector3(
                    transform.position.x, 
                    trailRenderer.transform.position.y,
                    transform.position.z);
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