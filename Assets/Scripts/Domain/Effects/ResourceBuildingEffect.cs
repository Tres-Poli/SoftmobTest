namespace Domain.Effects
{
    using System.Threading;
    using Cysharp.Threading.Tasks;

    public sealed class ResourceBuildingEffect : IBuildingEffect
    {
        private readonly EffectData _effectDataInfo;
        private readonly PlayerResources _playerResources;

        private CancellationTokenSource _cts;
        
        public ResourceBuildingEffect(EffectData effectDataInfo, PlayerResources playerResources)
        {
            _effectDataInfo = effectDataInfo;
            _playerResources = playerResources;
            _cts = new CancellationTokenSource();
        }
        
        public void Initialize()
        {
            DoTickAsync(_cts.Token).Forget();
        }
        
        private async UniTaskVoid DoTickAsync(CancellationToken ct)
        {
            await UniTask.Yield(PlayerLoopTiming.EarlyUpdate);

            while (!ct.IsCancellationRequested)
            {
                _playerResources.TryChange(_effectDataInfo.income);
                await UniTask.WaitForSeconds(_effectDataInfo.tickIntervalSec, false, PlayerLoopTiming.EarlyUpdate, cancellationToken: ct);
            }
        }

        public void Dispose()
        {
            _cts?.Dispose();
            _cts = null;
        }
    }
}