using System.Web.Http;
using Models;
using Repositories;
using Services;

namespace Controllers
{
    public class BaseApiController<TEntity, TRepository, TService> : ApiController
        where TEntity: BaseEntity
        where TRepository: BaseRepository<TEntity>, new()
        where TService: BaseService<TEntity, TRepository>, new()        
    {
        protected TService service = new TService();

        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(TEntity entity)
        {
            return Ok(service.Save(entity));
        }
    }
}
