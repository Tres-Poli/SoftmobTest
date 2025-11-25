namespace Application.UseCases.States.BuildingCreation
{
    using Domain.MessageDTO;
    using MessagePipe;

    public sealed class BuildingCreationChoiceState : UseCaseBase
    {
        private readonly IPublisher<ShowCreationContextMenuMessage> _showCreationMenuPub;
        private readonly ISubscriber<CreationContextMenuChoiceMessage> _creationChoiceSub;

        public BuildingCreationChoiceState(IPublisher<ShowCreationContextMenuMessage> showCreationMenuPub, ISubscriber<CreationContextMenuChoiceMessage> creationChoiceSub)
        {
            _showCreationMenuPub = showCreationMenuPub;
            _creationChoiceSub = creationChoiceSub;
        }
        
        public override void Initialize()
        {
            base.Initialize();
            _creationChoiceSub.Subscribe(BuildingChoice_Callback);
            
            _showCreationMenuPub.Publish(new ShowCreationContextMenuMessage());
        }

        private void BuildingChoice_Callback(CreationContextMenuChoiceMessage message)
        {
            // replace with resource check
            if (true)
            {
                // create building
            }
            
            Next<DefaultState>();
        }
    }
}