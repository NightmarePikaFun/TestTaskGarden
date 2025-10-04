using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField]
    private BuildingView buildingView;
    [SerializeField]
    private Button buildButton;
    [SerializeField]
    private Button destroyButton;

    private void Awake()
    {
        buildButton.onClick.AddListener(SwitchBuildingView);
        destroyButton.onClick.AddListener(ActivateDestroy);
        buildingView.Initialize();
    }

    public void SwitchBuildingView()
    {
        buildingView.SwitchView();
    }

    public void ActivateDestroy()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
