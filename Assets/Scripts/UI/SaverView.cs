using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using FileSystem;

public class SaverView : MonoBehaviour
{
    [SerializeField]
    private Button saveButton;
    [SerializeField]
    private Button loadButton;
    [SerializeField]
    private BuildingSpawner spawner;

    private FileController fileController;

    [Inject]
    private void Construct(FileController fController)
    {
        fileController = fController;
    }

    private void Awake()
    {
        saveButton.onClick.AddListener(() => fileController.SaveData());
        loadButton.onClick.AddListener(LoadData);
    }

    private void LoadData()
    {
        spawner.SpawnBuilding(fileController.LoadData());
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
