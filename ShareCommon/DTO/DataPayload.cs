﻿using ShareCommon.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareCommon.DTO
{
    public class DataPayload<T>
    {
        public int entity_id { get; set; }
        public PushType? action { get; set; }
        public string event_type { get; set; } = default!;
        public int user_id { get; set; }
        public T detail { get; set; } = default!;//json tuy bien
        public PriorityMessage? priority { get; set; }// high|medium|low

    }
}
