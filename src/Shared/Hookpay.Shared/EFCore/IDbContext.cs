﻿using Hookpay.Shared.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hookpay.Shared.EFCore;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    IExecutionStrategy CreateExcuteStrategy();
    Task ExecuteTransactionAsync(CancellationToken cancellationToken = default);
}
