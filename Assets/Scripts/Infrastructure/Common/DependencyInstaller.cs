namespace Infrastructure.Common
{
    using System;
    using UnityEngine;
    using VContainer;

    [Serializable]
    public abstract class DependencyInstaller : ScriptableObject
    {
        public abstract void Install(IContainerBuilder builder);
    }
}