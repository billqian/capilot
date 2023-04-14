using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Application.Services;

public interface IUnitOfWork
{
    void BeginTrans();

    void Commit();

    void Rollback();

    bool IsTransactionExists { get; }
}