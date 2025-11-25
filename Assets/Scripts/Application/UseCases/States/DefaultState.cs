namespace Application.UseCases.States
{
    using BuildingCreation;
    using BuildingManipulation;
    using ContractsInterfaces;
    using Domain.MessageDTO;
    using MessagePipe;

    public sealed class DefaultState : UseCaseBase
    {
        private readonly ISubscriber<TileClickedMessage> _tileClickedSubscriber;
        private readonly ISubscriber<BuildingClickedMessage> _buildingClickedSubscriber;
        private readonly IPublisher<TileOccupiedAlertMessage> _tileOccupiedPublisher;
        private readonly IBuildingService _buildingService;

        public DefaultState(ISubscriber<TileClickedMessage> tileClickedSubscriber, ISubscriber<BuildingClickedMessage>  buildingClickedSubscriber, 
            IPublisher<TileOccupiedAlertMessage> tileOccupiedPublisher, IBuildingService buildingService)
        {
            _tileClickedSubscriber = tileClickedSubscriber;
            _buildingClickedSubscriber = buildingClickedSubscriber;
            _tileOccupiedPublisher = tileOccupiedPublisher;
            _buildingService = buildingService;
        }
        
        public override void Initialize()
        {
            base.Initialize();
            disposables.Add(_tileClickedSubscriber.Subscribe(TileClicked_Callback));
            disposables.Add(_buildingClickedSubscriber.Subscribe(BuildingClicked_Callback));
        }

        private void TileClicked_Callback(TileClickedMessage message)
        {
            if (_buildingService.IsVacant(message.index))
            {
                Next<BuildingCreationChoiceState>();
                return;
            }
            
            _tileOccupiedPublisher.Publish(new TileOccupiedAlertMessage());
        }
        
        private void BuildingClicked_Callback(BuildingClickedMessage message)
        {
            Next<BuildingActionChoiceState>();
        }
    }
}