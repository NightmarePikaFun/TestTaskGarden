using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameLoop;
using System;

namespace GameData
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MovableBuilding buildingPrefab;

        private bool canBuild = false;

        private MovableBuilding movableBuilding;

        private BuildingController buildingController;
        private InputController inputController;
        private Action resetView;

        [Inject]
        private void Construct(BuildingController bController, InputController iController)
        {
            buildingController = bController;
            inputController = iController;
            
        }

        public void SetBuilding(Building building, Action reset)
        {
            inputController.SetPlaceAction(ActivateBuilding);
            canBuild = true;
            if (movableBuilding == null)
            {
                movableBuilding = Instantiate(buildingPrefab);
            }
            else
            {
                resetView?.Invoke();
            }
            movableBuilding.Construct(building, inputController);
        }

        public void Deactivate()
        {
            inputController.ClearMoveAction();
            inputController.ClearPlaceAction();
            if(movableBuilding != null)
                Destroy(movableBuilding.gameObject);
            movableBuilding = null;
            canBuild = false;
        }


        public void ActivateBuilding()
        {
            if (movableBuilding == null)
                return;
            if (canBuild && movableBuilding.CanPlace())
            {
                resetView?.Invoke();
                resetView = null;
                movableBuilding.Place();
                buildingController.AddNewBuilding(movableBuilding.GetBuldingInfo());
                movableBuilding = null;
                canBuild = false;
                inputController.ClearMoveAction();
                Debug.Log("+");
            }
        }
    }
}
