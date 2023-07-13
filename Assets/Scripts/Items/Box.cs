using System;
using UnityEngine;

namespace Items
{
    public class Box : Colliding
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Wall wall))
            {
                transform.SetParent(wall.transform);
            }
        }
    }
}