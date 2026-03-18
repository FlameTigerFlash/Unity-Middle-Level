using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class MyInstaller : MonoInstaller
{
    [SerializeField] private bool _useSmartSettingsLoader;
    public override void InstallBindings()
    {
        if (_useSmartSettingsLoader)
        {
            Container.Bind<ISettingsLoader>().To<SmartSettingsLoader>().AsSingle().NonLazy();
        }
        else
        {
            Container.Bind<ISettingsLoader>().To<DummySettingsLoader>().AsSingle().NonLazy();
        }
    }
}