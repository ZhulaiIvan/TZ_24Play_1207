using Effects;
using UnityEngine;
using Zenject;

public class EffectsHandlerInstaller : MonoInstaller
{
    [SerializeField] private EffectsHandler _handler;
    public override void InstallBindings()
    {
        Container
            .Bind<EffectsHandler>()
            .FromInstance(_handler)
            .AsSingle()
            .NonLazy();
    }
}