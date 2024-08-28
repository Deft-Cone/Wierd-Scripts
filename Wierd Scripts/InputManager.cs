/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input Manager")]
public class InputManager : ScriptableObject, GameInput.ILandActions, GameInput.IOnRailsActions, GameInput.IUIActions
{
    private GameInput _gameInput;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();

            _gameInput.Land.SetCallbacks(this);
            _gameInput.OnRails.SetCallbacks(this);
            _gameInput.UI.SetCallbacks(this);

            SetOnRails();
        }
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    public void SetThirdPerson()
    {
        _gameInput.Land.Enable();
        _gameInput.OnRails.Disable();
        _gameInput.UI.Disable();
    }

    public void SetOnRails()
    {
        _gameInput.Land.Disable();
        _gameInput.OnRails.Enable();
        _gameInput.UI.Disable();
    }

    public void SetUI()
    {
        _gameInput.Land.Disable();
        _gameInput.OnRails.Disable();
        _gameInput.UI.Enable();
    }

    public event Action<Vector2> MoveEvent;
    public event Action JumpEvent;
    public event Action JumpCanceledEvent;

    public event Action<Vector2> OnRailMoveEvent;
    public event Action<Vector2> RailAimEvent;
    public event Action RailFireEvent;
    public event Action RailDodgeEvent;
    public event Action RailDodgeCanceledEvent;

    public event Action PauseEvent;
    public event Action ResumeEvent;


    // THIRD PERSON ACTIONS
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpEvent?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            JumpCanceledEvent?.Invoke();
        }
    }

    // ON RAILS ACTIONS
    public void OnMoveOnRail(InputAction.CallbackContext context)
    {
        OnRailMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRailDodge(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            RailDodgeEvent?.Invoke();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            RailDodgeCanceledEvent?.Invoke();
        }
    }

    public void OnMousePos(InputAction.CallbackContext context)
    {
        RailAimEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRailFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            RailFireEvent?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            RailFireEvent?.Invoke();
        }
    }

    // UI ACTIONS
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
            SetUI();
        }
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
            // TODO: Set to last active ActionMap
            SetOnRails();
        }
    }


}
*/