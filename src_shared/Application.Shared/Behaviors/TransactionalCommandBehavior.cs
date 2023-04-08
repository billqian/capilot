﻿using Application.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Behaviors;

public class TransactionalCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;
    public TransactionalCommandBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is ITransactionalCommand) {
            
            var existTrans = _unitOfWork.ExistTransaction;
            if (existTrans) {
                return await next();
            } else { //没有事务环境，则创建
                try {
                    _unitOfWork.BeginTransaction();
                    //Console.WriteLine("事务启动");
                    var response = await next();
                    _unitOfWork.CommitTransaction();
                    //Console.WriteLine("事务提交");
                    return response;
                } catch {
                    //Console.WriteLine("事务回滚");
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        } else {
            return await next();
        }
    }
}
