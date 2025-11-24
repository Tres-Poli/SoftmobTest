namespace ContractsInterfaces
{
    using R3;
    using UnityEngine;

    public interface IInputService
    {
        public ReactiveProperty<Vector3> onLookValue { get; }
        public void Enable();
        public void Disable();
    }
}