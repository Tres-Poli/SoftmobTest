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
        private ReactiveProperty<Vector2> _onPointerClick = new();
        private ReactiveProperty<Vector2> _onPointer = new();
        public ReactiveProperty<Vector3> onLookValue => _onLookValue;
        public ReactiveProperty<Vector2> onPointerClick => _onPointerClick;
        public ReactiveProperty<Vector2> onPointer => _onPointer;

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

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _onPointerClick.Value = context.ReadValue<Vector2>();
                _onPointerClick.ForceNotify();
            }
        }

        public void OnPointer(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _onPointer.Value = value;
        }

        public void Dispose()
        {
            _inputActions.Player.RemoveCallbacks(this);
            _inputActions.Player.Disable();
            _inputActions.Dispose();
            _inputActions = null;

            _onLookValue.Dispose();
            _onPointerClick.Dispose();
            _onPointer.Dispose();
        }
    }
}