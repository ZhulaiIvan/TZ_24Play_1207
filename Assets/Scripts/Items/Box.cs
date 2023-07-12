using System;
using UnityEngine;

namespace Items
{
    public class Box : Movable
    {
        private void OnCollisionEnter(Collision collision)
        {
            // TODO: if wall - destroy component from obj
        }
    }
}