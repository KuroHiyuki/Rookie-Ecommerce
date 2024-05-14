using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure
{
    public static class RequestPipeline
    {
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            //app.UseMiddleware<EventualConsistencyMiddleware>();
            return app;
        }
    }
}
