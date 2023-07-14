using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Items
{
    public class StickMan : Colliding
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Wall _))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}