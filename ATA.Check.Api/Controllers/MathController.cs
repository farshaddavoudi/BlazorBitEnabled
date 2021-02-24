using Bit.OData.ODataControllers;

namespace ATA.Check.Api.Controllers
{
    public class MathController : DtoController
    {
        [Function]
        public int Sum(int n1, int n2)
        {
            return n1 + n2;
        }
    }
}
