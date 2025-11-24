namespace Infrastructure.Input
{
    using System;
    using ContractsInterfaces;
    using R3;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using VContainer;

    public sealed class InputService : IInputService, IDisposable, InputActions.IPlayerActions
    {
        private ReactiveProperty<Vector3> _onLookValue = new();
        public ReactiveProperty<Vector3> onLookValue => _onLookValue;
        
        private InputActions _inputActions;

        [Inject]
        public InputService()
        {
            _inputActions = new InputActions();
        }

        public void Enable()
        {
            _inputActions.Player.AddCallbacks(this);
            _inputActions.Player.Enable();
        }

        public void Disable()
        {
            _inputActions.Player.RemoveCallbacks(this);
            _inputActions.Player.Disable();
        }

        public void OnLookKeyboard(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _onLookValue.Value = context.ReadValue<Vector2>();
            }
            else if (!(context.started || context.performed))
            {
                _onLookValue.Value = Vector3.zero;
            }
        }

        public void OnDrag(InputAction.CallbackContext context)
        {
            //throw new System.NotImplementedException();
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            Debug.Log($"Value - {context.ReadValue<Vector2>()}");
            Debug.Log($"Started - {context.started}");
            Debug.Log($"Performed - {context.performed}");
        }

        public void Dispose()
        {
            _inputActions.Player.RemoveCallbacks(this);
            _inputActions.Player.Disable();
            _inputActions.Dispose();
            _inputActions = null;
        }
    }
}