using Player;
using UnityEngine;
using Zenject;

public class MovementControllerInstaller : MonoInstaller
{
    [SerializeField] private MovementController _controller;
    public override void InstallBindings()
    {
        Container
            .Bind<MovementController>()
            .FromInstance(_controller)
            .AsSingle()
            .NonLazy();
    }
}