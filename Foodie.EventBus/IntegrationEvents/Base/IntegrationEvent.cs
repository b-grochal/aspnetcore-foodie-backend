using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.EventBus.IntegrationEvents.Base
{
    public interface IntegrationEvent
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
