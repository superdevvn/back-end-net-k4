using System;
using System.Net;
using System.Web.Http;
using Models;
using Newtonsoft.Json.Linq;
using Repositories;
using Services;

namespace Controllers
{
    [RoutePrefix("api/transactiondetail")]
    public class TransactionDetailApiController : BaseApiController<TransactionDetail, TransactionDetailRepository, TransactionDetailService>
    {
    }
}