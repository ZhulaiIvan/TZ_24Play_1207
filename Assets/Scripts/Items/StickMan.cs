using UnityEngine;
using UnityEngine.SceneManagement;

namespace Items
{
    [RequireComponent(typeof(Rigidbody))]
    public class StickMan : CollidingItem
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall _))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}