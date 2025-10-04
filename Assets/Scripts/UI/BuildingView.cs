using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingView : MonoBehaviour
{
    [SerializeField]
    private BuildingElement buildingPrefab;
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private List<BuildingElement> buildings;

    private GameManager gameManager;
    public void Initialize()
    {
        canvasGroup.alpha = 0;
    }

    public void SwitchView()
    {
        canvasGroup.alpha = canvasGroup.alpha == 1 ? 0 : 1;
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
