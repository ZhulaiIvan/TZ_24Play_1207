using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class PickupHandler : MonoBehaviour
    {
        [SerializeField] private StickMan _stickMan;
        [SerializeField] private Pickup _lastPickup;
        
        private List<Pickup> _pickups = new();

        private void Start()
        {
            _lastPickup.OnPickupTriggered += PickupTriggered;
            _pickups.Add(_lastPickup);
        }

        private void PickupTriggered(Pickup pickup)
        {
            _stickMan.transform.position += Vector3.up;
            
            pickup.transform.position = _lastPickup.transform.position + Vector3.up;
            pickup.transform.SetParent(transform);
            pickup.Rigidbody.useGravity = true;
            pickup.OnPickupTriggered += PickupTriggered;

            _lastPickup = pickup;
            _pickups.Add(pickup);
        }

        private void OnDestroy()
        {
            foreach (Pickup pickup in _pickups)
            {
                pickup.OnPickupTriggered -= PickupTriggered;
            }

            _pickups.Clear();
        }
    }
}