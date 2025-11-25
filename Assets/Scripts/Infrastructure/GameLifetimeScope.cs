namespace Infrastructure
{
    using System.Collections.Generic;
    using Common;
    using Domain.MessageDTO;
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

            builder.RegisterMessageBroker<TilePointedMessage>(messagePipeOptions);
            builder.RegisterMessageBroker<TileClickedMessage>(messagePipeOptions);
            builder.RegisterMessageBroker<BuildingClickedMessage>(messagePipeOptions);
            builder.RegisterMessageBroker<TileOccupiedAlertMessage>(messagePipeOptions);
            builder.RegisterMessageBroker<NotEnoughResourceAlertMessage>(messagePipeOptions);
            //builder.RegisterMessageBroker<int>(messagePipeOptions);
        }
    }
}