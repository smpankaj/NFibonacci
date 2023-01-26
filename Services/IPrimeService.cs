
using System.Numerics;

namespace NFibonacci.Services
{
    public interface IPrimeService
    {
        BigInteger GetNthPrime(BigInteger num);

    }
}
