using UnityEngine;
using Zenject;
using RogueLike.QuestSystem;

public class QuestInstaller : MonoInstaller
{
    [SerializeField] private QuestService questService;

    public override void InstallBindings()
    {
        Container.Bind<IQuestService>()
                 .To<QuestService>()
                 .FromInstance(questService)
                 .AsSingle()
                 .Lazy();
    }
}