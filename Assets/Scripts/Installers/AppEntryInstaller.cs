using Core;
using UnityEngine;
using Zenject;

public class AppEntryInstaller : MonoInstaller
{
   [SerializeField] private AppEntry _appEntry;

   public override void InstallBindings()
   {
      Container
         .Bind<AppEntry>()
         .FromInstance(_appEntry)
         .AsSingle()
         .NonLazy();
   }
}