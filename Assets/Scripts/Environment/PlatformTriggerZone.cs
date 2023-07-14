using System;
using Items;
using Player;
using UnityEngine;

namespace Environment
{
    public class PlatformTriggerZone : MonoBehaviour
    {
        public event Action OnTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out StickMan _)) return;

            OnTriggered?.Invoke();
        }
    }
}