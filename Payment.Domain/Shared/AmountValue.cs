using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Shared
{
	public record AmountValue
	{
		public double Value { get; init; }

		public AmountValue(double value)
		{
			if (value < 0)
			{
				throw new ArgumentException("Amount value cannot be negative", nameof(value));
			}
            if (value > 1500)
            {
                throw new ArgumentException("Amount value cannot be > 1500", nameof(value));
            }

            Value = value;
		}

		public static implicit operator double(AmountValue quantity)
		{
			return quantity == null ? 0 : quantity.Value;
		}

		public static implicit operator AmountValue(double a)
		{
			return new AmountValue(a);
		}
	}
}
