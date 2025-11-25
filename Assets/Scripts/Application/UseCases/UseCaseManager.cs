namespace Application.UseCases
{
    using Domain.MessageDTO;
    using MessagePipe;
    using StateBuilders;

    public sealed class UseCaseManager
    {
        private IUseCaseState _currentState;

        private readonly StateBuilder _stateBuilder;

        public UseCaseManager()
        {
            
        }

        public void Next<T>() where T : class, IUseCaseState
        {
            var builtState = _stateBuilder.Build<T>();
            if (builtState == null)
            {
                return;
            }
            
            _currentState.Dispose();
            _currentState = builtState;
            _currentState.Initialize();
        }
    }
}