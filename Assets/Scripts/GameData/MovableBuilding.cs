using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameLoop
{
    public class MovableBuilding : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider2D collider;
        [SerializeField]
        private Rigidbody2D rb;
        [SerializeField]
        private BuildingInfo buildingInfo;

        private int collisionCounter = 0;

        public void Construct(Building building, InputController inputController)
        {
            buildingInfo.Construct(building);
            inputController.SetMoveAction(MouseMove, KeyMove);
        }

        public void Place()
        {
            Destroy(this);
        }

        public void MouseMove(Vector3Int moveVector)
        {
            transform.position = moveVector;
        }

        public void KeyMove(Vector3Int moveVector)
        {
            transform.position += moveVector;
        }

        public BuildingInfo GetBuldingInfo() => buildingInfo;

        public bool CanPlace() => collisionCounter == 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            collisionCounter++;

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            collisionCounter--;
            if (collisionCounter == 0)
                GetComponent<SpriteRenderer>().color = Color.white;
        }

        private void OnDestroy()
        {
            collider.isTrigger = true;
            Destroy(rb);
        }
    }
}
