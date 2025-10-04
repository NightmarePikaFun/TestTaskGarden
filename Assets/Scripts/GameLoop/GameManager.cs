using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoInstaller
{
    [SerializeField]
    private GameController controller;

    private BuildingController buildController = new BuildingController();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public override void InstallBindings()
    {
        Container.Bind<GameController>()
            .FromInstance(controller)
            .AsCached();
        Container.Bind<BuildingController>()
            .FromInstance(buildController)
            .AsCached();
    }
}
