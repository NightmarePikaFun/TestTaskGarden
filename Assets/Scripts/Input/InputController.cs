using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction mouseAction;
    private InputAction moveAction;
    private InputAction camMouseAction;
    private InputAction fireAction;

    private Action<Vector3Int> actionMove;
    private Action actionPlace;

    private Camera cam;


    private void Awake()
    {
        cam = Camera.main;
        playerControls = new PlayerControls();
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        mouseAction = playerControls.Player.Look;
        moveAction = playerControls.Player.Move;
        camMouseAction = playerControls.Player.MouseMove;
        fireAction = playerControls.Player.Fire;

        moveAction.Enable();
        mouseAction.Enable();
        camMouseAction.Enable();
        fireAction.Enable();

        moveAction.performed += Move;
        mouseAction.performed += MouseMove;
        fireAction.performed += PlaceAction;
    }

    private void Move(InputAction.CallbackContext callback)
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        Vector3Int moveVector = new Vector3Int(Mathf.RoundToInt(moveDirection.x), Mathf.RoundToInt(moveDirection.y), 0);
        actionMove?.Invoke(moveVector);
    }

    private void MouseMove(InputAction.CallbackContext callback)
    {
        Vector2 moveDirection = camMouseAction.ReadValue<Vector2>();
        if(cam == null)
            cam = Camera.main;
        Vector3Int moveVector = RoundToInt(cam.ScreenToWorldPoint(new Vector3(moveDirection.x, moveDirection.y, 10)));
        actionMove?.Invoke(moveVector);
    }

    private void PlaceAction(InputAction.CallbackContext callback)
    {
        actionPlace?.Invoke();
    }

    private Vector3Int RoundToInt(Vector3 vector)
    {
        return Vector3Int.RoundToInt(vector);
    }

    public void SetPlaceAction(Action action)
    {
        actionPlace = action;
    }

    public void SetMoveAction(Action<Vector3Int> action)
    {
        actionMove = action;
    }

    public void ClearMoveAction()
    {
        actionMove = null;
    }
}
