using Items;
using UnityEngine;
using Zenject;

public class CubesHandlerInstaller : MonoInstaller
{
    [SerializeField] private CubesHandler _handler;

    public override void InstallBindings()
    {
        Container
            .Bind<CubesHandler>()
            .FromInstance(_handler)
            .AsSingle()
            .NonLazy();
    }
}