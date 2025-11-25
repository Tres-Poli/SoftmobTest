namespace Domain
{
    using Common;

    public class PlayerResources
    {
        private CityResource _value;

        public CityResource resourceValue => _value;

        public PlayerResources(int money = 0, int people = 0, int control = 0)
        {
            _value = new CityResource
            {
                money = money,
                people = people,
                control = control
            };
        }

        public PlayerResources(CityResource value)
        {
            _value = value;
        }

        public bool TryChange(CityResource increment)
        {
            var result = _value + increment;
            if (result.money < 0 || result.people < 0 || result.control < 0)
            {
                return false;
            }

            _value = result;
            return true;
        }
        
        public bool CanAfford(CityResource price)
        {
            return _value >= price;
        }
    }
}