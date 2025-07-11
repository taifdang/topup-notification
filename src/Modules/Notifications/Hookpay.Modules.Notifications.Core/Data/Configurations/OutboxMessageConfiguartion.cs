﻿using Hookpay.Modules.Notifications.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hookpay.Modules.Notifications.Core.Data.Configurations;

public class OutboxMessageConfiguartion : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(x => x.id).ValueGeneratedOnAdd();

        builder.Property(x => x.status).HasDefaultValue(default);
    }
}
