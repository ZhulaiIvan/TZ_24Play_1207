using UnityEngine;

namespace Effects
{
    public class EffectsHandler : MonoBehaviour
    {
        [SerializeField] private Effect[] _effectsPool;
        
        public void Play(EffectType type, Vector3 position)
        {
            foreach (Effect effect in _effectsPool)
            {
                if(effect.Type != type) continue;
                
                foreach (ParticleSystem particle in effect.Particles)
                {
                    ParticleSystem newParticle = Instantiate(particle);
                    newParticle.transform.position = position;
                    newParticle.Play();
                }

                if (effect.IsVibrate)
                    Handheld.Vibrate();
            }
        }
    }

    public enum EffectType
    {
        Picked,
        Collide
    }
}