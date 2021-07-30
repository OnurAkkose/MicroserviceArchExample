﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Events.Interfaces
{
    public abstract class IEvent
    {
        public Guid RequestId { get; set; }
        public DateTime CreationDate { get; set; }

        public IEvent()
        {
            RequestId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
