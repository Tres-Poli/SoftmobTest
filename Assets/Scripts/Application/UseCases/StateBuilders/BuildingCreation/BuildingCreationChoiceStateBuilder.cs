namespace Application.UseCases.StateBuilders.BuildingCreation
{
    using Domain.MessageDTO;
    using MessagePipe;
    using States.BuildingCreation;

    public sealed class BuildingCreationChoiceStateBuilder : IUseCaseStateBuilder
    {
        private readonly IPublisher<ShowCreationContextMenuMessage> _showCreationMenuPub;
        private readonly ISubscriber<CreationContextMenuChoiceMessage> _creationChoiceSub;

        public BuildingCreationChoiceStateBuilder(IPublisher<ShowCreationContextMenuMessage> showCreationMenuPub, 
            ISubscriber<CreationContextMenuChoiceMessage> creationChoiceSub)
        {
            _showCreationMenuPub = showCreationMenuPub;
            _creationChoiceSub = creationChoiceSub;
        }
        
        public IUseCaseState Build()
        {
            return new BuildingCreationChoiceState(_showCreationMenuPub, _creationChoiceSub);
        }
    }
}