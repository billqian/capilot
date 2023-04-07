using FluentValidation;
using MediatR.NotificationPublishers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ConfigureServices
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddOptionsWithFluentValidation<CreateTodoItemCommandOptions, CreateTodoItemCommandOptionsValidator>(config);

        services.AddMediatR((cfg) => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionLoggerBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionalCommandBehavior<,>));

            cfg.NotificationPublisher = new TaskWhenAllPublisher();  //处理程序并行
            //cfg.NotificationPublisher = new ForeachAwaitPublisher(); //处理器一个一个的执行，默认模式
        });

        return services;
    }
}
