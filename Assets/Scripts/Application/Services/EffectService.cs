namespace Application.Services.Camera
{
    using System;
    using ContractsInterfaces;
    using Domain.Common;
    using Domain.Effects;

    public class EffectService
    {
        private readonly IEffectRepository _effectRepository;

        private EffectData[] _effectDataMap;

        public EffectService(IEffectRepository effectRepository)
        {
            _effectRepository = effectRepository;

            var effectsCount = Enum.GetValues(typeof(EffectType)).Length;
            _effectDataMap = new EffectData[effectsCount];
        }
    }
}