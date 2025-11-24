namespace Domain.Common
{
    using System;

    [Serializable]
    public struct CityResource
    {
        public int money;
        public int people;
        public int control;

        public static CityResource defaultValue => new CityResource(0, 0, 0);

        public CityResource(int money, int people, int control)
        {
            this.money = money;
            this.people = people;
            this.control = control;
        }

        public static bool operator ==(CityResource left, CityResource right)
        {
            return left.money == right.money && left.people == right.people && left.control == right.control;
        }
        
        public static bool operator !=(CityResource left, CityResource right)
        {
            return left.money != right.money ||  left.people != right.people || left.control != right.control;
        }
        
        public static CityResource operator +(CityResource left, CityResource right)
        {
            return new CityResource
            {
                money = left.money + right.money,
                people = left.people + right.people,
                control = left.control + right.control
            };
        }

        public static CityResource operator -(CityResource left, CityResource right)
        {
            return new CityResource
            {
                money = left.money - right.money,
                people = left.people - right.people,
                control = left.control - right.control
            };
        }

        public static bool operator >=(CityResource left, CityResource right)
        {
            return left.money >= right.money && left.people >= right.people && left.control >= right.control;
        }
        
        public static bool operator <=(CityResource left, CityResource right)
        {
            return left.money <= right.money && left.people <= right.people && left.control <= right.control;
        }
    }
}