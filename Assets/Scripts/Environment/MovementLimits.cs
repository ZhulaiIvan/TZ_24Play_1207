using PlayerInput;
using UnityEngine;

namespace Environment
{
    public class MovementLimits : MonoBehaviour
    {
        [Header("Platform object for sides movement limit"), SerializeField]
        private Renderer _platformRenderer;
        
        public float MaxX => _platformRenderer.bounds.max.x;
        public float MinX => _platformRenderer.bounds.min.x;

        private void Start()
        {
            if (_platformRenderer == null)
                Debug.LogError("Do not have movement limits");
        }
    }
}