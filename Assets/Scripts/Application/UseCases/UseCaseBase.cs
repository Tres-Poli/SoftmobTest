namespace Application.UseCases
{
    using System;
    using R3;

    public class UseCaseBase : IUseCaseState
    {
        public ReactiveProperty<Type> onNextState = new();
        protected CompositeDisposable disposables = new();

        protected virtual void Next<T>() where T : class, IUseCaseState
        {
            onNextState.Value = typeof(T);
        }
        
        public virtual void Initialize()
        {
            disposables.Add(onNextState);
        }
        
        public virtual void Dispose()
        {
            disposables.Dispose();
        }
    }
}