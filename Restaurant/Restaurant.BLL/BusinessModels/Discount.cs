using System;

namespace Restaurant.BLL.BusinessModels
{
    public class Discount
    {
        private decimal _value = 0;
        public decimal Value { get { return _value; } }

        public Discount(decimal val)
        {
            _value = val;
        }
        
        public decimal GetDiscountPrice(decimal sum)
        {
            if((int)DateTime.Now.DayOfWeek > 0 && (int)DateTime.Now.DayOfWeek < 5)
            {
                return sum - sum * _value;
            }
            return sum;
        }
    }
}
