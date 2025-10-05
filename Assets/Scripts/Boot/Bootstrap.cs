using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using GameData;
using FileSystem;

public class Bootstrap : MonoInstaller
{
    [SerializeField]
    private GameController controller;
    [SerializeField]
    private InputController inputController;
    [SerializeField]
    private FileController fileController;

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
        Container.Bind<FileController>()
            .FromInstance(fileController)
            .AsCached();
    }
}
