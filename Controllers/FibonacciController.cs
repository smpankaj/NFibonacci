using Microsoft.AspNetCore.Mvc;
using NFibonacci.Services;
using System.Numerics;

namespace NFibonacci.Controllers
{
	//[Route("api/[controller]")]
	[Route("/")]

	[ApiController]
	public class FibonacciController : ControllerBase
	{
		private readonly IPrimeService _primeService;

		public FibonacciController(IPrimeService primeService)
		{ 
			_primeService = primeService;
		}
	
		/// <summary>
		/// The following function accepts a stringified number and returns the fibonacci number
		/// </summary>
		/// <param name="num">Stringified BigInteger</param>
		/// <returns>The stringified fibonacci number</returns>
		[HttpGet]
		public IActionResult CheckPrime(string num)
		{
			BigInteger result;
			// If num string isn't numeric, return the imvalid input message
			if (!BigInteger.TryParse(num, out result))
				return StatusCode(StatusCodes.Status200OK,"Invalid integer passed");
			if (result < 1)
                return StatusCode(StatusCodes.Status200OK, "Passed integer should be greater than 0");
			try
			{
                // use the prime service to get the fibonacci number
				var fib = _primeService.GetNthPrime(result);
                return StatusCode(StatusCodes.Status200OK, fib.ToString());
            }
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
           
		}
	}
}
