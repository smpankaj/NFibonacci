
using System.Numerics;

namespace NFibonacci.Services
{
    public class PrimeService : IPrimeService
    {
        /// <summary>
        /// Get the fibonacci number at a position
        /// </summary>
        /// <param name="num">It is the position for which we want to get the fibonacci number</param>
        /// <returns>Fibonacci number</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public  BigInteger GetNthPrime(BigInteger num)
        {
            try
            {
                if (num < 1)
                    throw new ArgumentException("The searched value should be greater than or equal to 1");
               
                // The fibonacci sequences starts with 0. The first number in the sequence is 0 and the second number is 1
                if (num == 1)
                    return 0;

                if (num == 2)
                    return 1;

                BigInteger prev = 0, cur = 1, temp;
                for(int i = 3; i <= num; i++)
                {
                    temp = cur + prev;
                    prev = cur;
                    cur = temp;
                }
                return cur;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
