namespace Application.UseCases.StateBuilders
{
    using System;
    using System.Collections.Generic;
    using BuildingCreation;
    using ContractsInterfaces;
    using Domain.MessageDTO;
    using MessagePipe;
    using States;
    using States.BuildingCreation;
    using UnityEngine;

    public sealed class StateBuilder
    {
        private Dictionary<Type, IUseCaseStateBuilder> _buildersMap;
        
        public StateBuilder(ISubscriber<TileClickedMessage> tileClickedSub, 
            ISubscriber<BuildingClickedMessage>  buildingClickedSub, IPublisher<TileOccupiedAlertMessage> tileOccupiedPub, 
            IPublisher<ShowCreationContextMenuMessage> showCreationContextPub, ISubscriber<CreationContextMenuChoiceMessage> creationMenuChoiceSub, IBuildingService buildingService)
        {
            _buildersMap = new Dictionary<Type, IUseCaseStateBuilder>();
            
            _buildersMap.Add(typeof(DefaultState), new DefaultStateBuilder(tileClickedSub, buildingClickedSub, tileOccupiedPub, buildingService));
            
            _buildersMap.Add(typeof(BuildingCreationChoiceState), new BuildingCreationChoiceStateBuilder(showCreationContextPub, creationMenuChoiceSub));
        }

        public T Build<T>() where T : class, IUseCaseState
        {
            if (_buildersMap.TryGetValue(typeof(T), out var builder))
            {
                return (T)builder.Build();
            }
            
            Debug.LogError($"[StateBuilder].[Build]: Abstract builder could not find specific builder for type ({typeof(T).Name})");
            return null;
        }
    }
}