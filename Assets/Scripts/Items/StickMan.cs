using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Items
{
    [RequireComponent(typeof(Rigidbody))]
    public class StickMan : CollidingItem
    {
        private AppEntry _entry;

        [Inject]
        public void Construct(AppEntry entry)
        {
            _entry = entry;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall _))
            {
                _entry.UpdateState(AppState.Lose);
            }
        }
    }
}