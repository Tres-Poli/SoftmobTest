namespace Application.UseCases.StateBuilders
{
    using ContractsInterfaces;
    using Domain.MessageDTO;
    using MessagePipe;
    using States;

    public sealed class DefaultStateBuilder : IUseCaseStateBuilder
    {
        private readonly ISubscriber<TileClickedMessage> _tileClickedSubscriber;
        private readonly ISubscriber<BuildingClickedMessage> _buildingClickedSubscriber;
        private readonly IPublisher<TileOccupiedAlertMessage> _tileOccupiedPublisher;
        private readonly IBuildingService _buildingService;

        public DefaultStateBuilder(ISubscriber<TileClickedMessage> tileClickedSubscriber, 
            ISubscriber<BuildingClickedMessage>  buildingClickedSubscriber, IPublisher<TileOccupiedAlertMessage> tileOccupiedPublisher, 
            IBuildingService buildingService)
        {
            _tileClickedSubscriber = tileClickedSubscriber;
            _buildingClickedSubscriber = buildingClickedSubscriber;
            _tileOccupiedPublisher = tileOccupiedPublisher;
            _buildingService = buildingService;
        }

        public IUseCaseState Build()
        {
            return new DefaultState(_tileClickedSubscriber, _buildingClickedSubscriber, _tileOccupiedPublisher, _buildingService);
        }
    }
}