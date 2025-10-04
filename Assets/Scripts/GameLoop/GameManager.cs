using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameData;

public class GameManager : MonoInstaller
{
    [SerializeField]
    private GameController controller;
    [SerializeField]
    private InputController inputController;

    private BuildingController buildController = new BuildingController();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public override void InstallBindings()
    {
        inputController = Instantiate(inputController);
        Container.Bind<GameController>()
            .FromInstance(controller)
            .AsCached();
        Container.Bind<BuildingController>()
            .FromInstance(buildController)
            .AsCached();
        Container.Bind<InputController>()
            .FromInstance(inputController)
            .AsCached();
    }
}

