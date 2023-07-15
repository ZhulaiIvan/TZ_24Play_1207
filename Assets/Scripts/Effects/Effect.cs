using UnityEngine;

namespace Effects
{
    public class Effect : MonoBehaviour
    {
        public EffectType Type;
        public ParticleSystem[] Particles;
        public bool IsVibrate;
    }
}