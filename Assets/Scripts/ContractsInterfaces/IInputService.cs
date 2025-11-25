namespace ContractsInterfaces
{
    using R3;
    using UnityEngine;

    public interface IInputService
    {
        public ReactiveProperty<Vector3> onLookValue { get; }
        public ReactiveProperty<Vector2> onPointerClick { get; }
        public ReactiveProperty<Vector2> onPointer { get; }
        public void Enable();
        public void Disable();
    }
}