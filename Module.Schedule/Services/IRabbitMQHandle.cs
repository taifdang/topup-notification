﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Schedule.Services
{
    public interface IRabbitMQHandle
    {       
        Task ScheduleAsync(IChannel channel,IEnumerable<string> listdata);
    }
}
