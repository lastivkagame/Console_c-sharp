using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Money
    {
        private double sumHryvnias;

        public double SumHryvnias
        {
            get { return sumHryvnias; }
            set
            {
                if (value >= 0)
                {
                    sumHryvnias = value;
                }
                else
                {
                    throw new ExceptionBankruptcy();
                }
            }
        }

        public Money(double sumHryvnias = 0)
        {
            SumHryvnias = sumHryvnias;
        }

        #region OverloadOperators
        public static Money operator +(Money sum, double sum2)
        {
            if ((sum2 >= 0) && (sum2 + sum.sumHryvnias > 0))
            {
                return new Money(sum.sumHryvnias + sum2);
            }

            throw new ExceptionBankruptcy();
        }

        public static Money operator -(Money sum, double sum2)
        {
            if ((sum2 >= 0) && (sum.sumHryvnias - sum2 > 0))
            {
                return new Money(sum.sumHryvnias - sum2);
            }

            throw new ExceptionBankruptcy();
        }

        public static Money operator *(Money sum, int sum2)
        {
            if (sum2 >= 0)
            {
                return new Money(sum.sumHryvnias * sum2);
            }

            throw new ExceptionBankruptcy();
        }

        public static Money operator /(Money sum, int sum2)
        {
            if (sum2 > 0)
            {
                return new Money(sum.sumHryvnias / sum2);
            }
            else if (sum2 == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                throw new ExceptionBankruptcy();
            }
        }

        public static Money operator ++(Money sum)
        {
            sum.sumHryvnias += 0.1;
            return sum;
        }

        public static Money operator --(Money sum)
        {
            sum.sumHryvnias -= 0.1;
            return sum;
        }

        public static bool operator ==(Money sum1, Money sum2)
        {
            return sum1.SumHryvnias == sum2.SumHryvnias;
        }

        public static bool operator !=(Money sum1, Money sum2)
        {
            return sum1.SumHryvnias != sum2.SumHryvnias;
        }

        public static bool operator true(Money sum)
        {
            return sum.sumHryvnias != 0;
        }

        public static bool operator false(Money sum)
        {
            return sum.sumHryvnias == 0;
        }

        public static bool operator <(Money sum1, Money sum2)
        {
            return sum1.sumHryvnias < sum2.sumHryvnias;
        }

        public static bool operator >(Money sum1, Money sum2)
        {
            return sum1.sumHryvnias > sum2.sumHryvnias;
        }
        #endregion

        public override string ToString()
        {
            return SumHryvnias.ToString() + " UAH";
        }

    }
}
