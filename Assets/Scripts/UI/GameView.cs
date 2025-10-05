using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameView : MonoBehaviour
{
    [SerializeField]
    private BuildingView buildingView;
    [SerializeField]
    private Button buildButton;
    [SerializeField]
    private Button destroyButton;
    [SerializeField]
    private Cleaner cleaner;

    private InputController inputController;

    [Inject]
    private void Construct(InputController iController)
    {
        inputController = iController;
    }

    private void Awake()
    {
        buildButton.onClick.AddListener(SwitchBuildingView);
        destroyButton.onClick.AddListener(ActivateDestroy);
        inputController.SetCancelAction(Cancel);
    }

    void Start()
    {
        buildingView.Initialize();
    }

    public void SwitchBuildingView()
    {
        buildingView.SwitchView();
        cleaner.DisableClean();
    }

    public void ActivateDestroy()
    {
        buildingView.HideView();
        cleaner.EnableClean();
    }

    private void Cancel()
    {
        buildingView.HideView();
        cleaner.DisableClean();
        inputController.ClearPlaceAction();
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
