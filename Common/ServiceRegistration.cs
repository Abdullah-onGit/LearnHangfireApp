using ClientApi.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection _services)
        {

            _services.AddScoped<IReportService, ReportService>();
            _services.AddScoped<IReportRepostory, ReportRepostory>();
            return _services;
        }
    }
}
