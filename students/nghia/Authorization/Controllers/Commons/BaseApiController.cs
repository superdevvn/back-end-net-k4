using System;
using System.Collections.Generic;
using System.Web.Http;
using Models.Interfaces;
using Newtonsoft.Json.Linq;
using Repositories;
using Repositories.Commons;
using Services;

namespace Controllers
{
    public class BaseApiController<TEntity, TRepository, TBaseService> : ApiController
        where TEntity : class, IModel, IClient, ICreator
        where TRepository : BaseRepository<TEntity>, new()
        where TBaseService : BaseService<TEntity, TRepository>, new()
    {
        protected TBaseService service = new TBaseService();

        [HttpPost]
        [Route("list")]
        public virtual IHttpActionResult List(PagedListRequest request)
        {
            return Ok(service.List(request));
        }

        [HttpPost]
        [Route("all")]
        public virtual IHttpActionResult All(JObject json)
        {
            string whereClause = (json != null && json["whereClause"] != null) ? json["whereClause"].ToString() : null;
            return Ok(service.All(whereClause));
        }

        [HttpGet]
        [Route("get")]
        public virtual IHttpActionResult Get(Guid id)
        {
            return Ok(service.One(id));
        }

        [HttpPost]
        [Route("save")]
        public virtual IHttpActionResult Save(TEntity entity)
        {
            return Ok(service.Save(entity));
        }

        [HttpPost]
        [Route("createEntities")]
        public virtual IHttpActionResult Create(IEnumerable<TEntity> entities)
        {
            service.Create(entities);
            return Ok();
        }

        [HttpPost]
        [Route("updateEntities")]
        public virtual IHttpActionResult Update(IEnumerable<TEntity> entities)
        {
            service.Update(entities);
            return Ok();
        }

        [HttpPost]
        [Route("approve")]
        public virtual IHttpActionResult Approve(JObject json)
        {
            if (json == null || json["id"] == null) throw new Exception("ID REQUIRED");
            if (Guid.TryParse(json["id"].ToString(), out Guid id))
            {
                service.Approve(id);
                return Ok();
            }
            else throw new Exception("INVALID GUID");
        }

        [HttpPost]
        [Route("approveEntities")]
        public virtual IHttpActionResult ApproveEntities(List<Guid> ids)
        {
            service.Approve(ids);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public virtual IHttpActionResult Delete(JObject json)
        {
            if (json == null || json["id"] == null) throw new Exception("ID REQUIRED");
            if (Guid.TryParse(json["id"].ToString(), out Guid id))
            {
                service.Delete(id);
                return Ok();
            }
            else throw new Exception("INVALID GUID");
        }

        [HttpPost]
        [Route("deleteEntities")]
        public virtual IHttpActionResult DeleteEntities(IEnumerable<Guid> ids)
        {
            service.Delete(ids);
            return Ok();
        }
    }
}
