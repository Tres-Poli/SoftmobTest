namespace Application.UseCases
{
    using System;

    public interface IUseCaseState : IDisposable
    {
        public void Initialize();
    }
}