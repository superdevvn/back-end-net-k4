using System.Web.Http;
using Models;
using Repositories;
using Services;

namespace Controllers
{
    [RoutePrefix("api/transaction")]
    public class TransactionApiController : BaseApiController<Transaction, TransactionRepository, TransactionService>
    {
    }
}