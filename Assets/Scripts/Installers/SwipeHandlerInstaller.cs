using PlayerInput;
using UnityEngine;
using Zenject;

public class SwipeHandlerInstaller : MonoInstaller
{
    [SerializeField] private SwipeHandler _handler;
    public override void InstallBindings()
    {
        Container
            .Bind<SwipeHandler>()
            .FromInstance(_handler)
            .AsSingle()
            .NonLazy();
    }
}
