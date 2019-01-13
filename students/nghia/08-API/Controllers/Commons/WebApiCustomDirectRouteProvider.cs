using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace Controllers.Commons
{
    public class WebApiCustomDirectRouteProvider : DefaultDirectRouteProvider
    {
        protected override System.Collections.Generic.IReadOnlyList<IDirectRouteFactory>
            GetActionRouteFactories(System.Web.Http.Controllers.HttpActionDescriptor actionDescriptor)
        {
            // inherit route attributes decorated on base class controller's actions
            return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
        }
    }
}
