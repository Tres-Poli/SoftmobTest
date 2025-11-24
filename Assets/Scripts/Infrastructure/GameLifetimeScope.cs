namespace Infrastructure
{
    using System.Collections.Generic;
    using Common;
    using MessagePipe;
    using UnityEngine;
    using VContainer;
    using VContainer.Unity;

    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<DependencyInstaller> _installers = new();
        
        protected override void Configure(IContainerBuilder builder)
        {
            var messagePipeOptions = builder.RegisterMessagePipe();
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            foreach (var installer in _installers)
            {
                installer.Install(builder);
            }

            Debug.Log("test");
            //builder.RegisterMessageBroker<int>(messagePipeOptions);
        }
    }
}