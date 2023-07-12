using Environment;
using UnityEngine;
using Zenject;

public class MovementLimitsInstaller : MonoInstaller
{
    [SerializeField] private MovementLimits _limits;

    public override void InstallBindings()
    {
        Container
            .Bind<MovementLimits>()
            .FromInstance(_limits)
            .AsSingle();
    }
}