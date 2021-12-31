using UnityEngine;
using Zenject;
using RogueLike.UINavigation;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private FpsCounterView fpsCounter;

    public override void InstallBindings()
    {
        fpsCounter = Container.InstantiatePrefabForComponent<FpsCounterView>(fpsCounter.gameObject);

        Container.Bind<FpsCounterView>()
                 .To<FpsCounterView>()
                 .FromInstance(fpsCounter)
                 .AsSingle()
                 .NonLazy();
    }
}