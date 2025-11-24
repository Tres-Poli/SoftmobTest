namespace Domain.Buildings.Effects
{
    public class MoneyBuildingEffect : IBuildingEffect
    {
        private int _tickValue;
        
        public MoneyBuildingEffect(int tickValue)
        {
            _tickValue  = tickValue;
        }
        
        public void Tick()
        {
            
        }
    }
}