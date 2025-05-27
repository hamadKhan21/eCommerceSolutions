using eCommerce.Core.Services;
using eCommerce.Core.ServicesContract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core;

    public static class DepdennciesInjection
    {

    public static IServiceCollection AddCore(this IServiceCollection service)
    {

        service.AddScoped<IUserServices, UserServices>();

        return service;
    } 


    }

