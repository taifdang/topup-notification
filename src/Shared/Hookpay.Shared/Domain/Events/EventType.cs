﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hookpay.Shared.Domain.Events;

[Flags]
public enum EventType
{
    InteragationEvent = 1,
    DomainEvent = 2
}
