using Core;
using UnityEngine;
using Zenject;

public class AppCoreInstaller : MonoInstaller
{
   [SerializeField] private AppCore appCore;

   public override void InstallBindings()
   {
      Container
         .Bind<AppCore>()
         .FromInstance(appCore)
         .AsSingle()
         .NonLazy();
   }
}