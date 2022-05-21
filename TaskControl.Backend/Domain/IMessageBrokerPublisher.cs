using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Domain
{
    public interface IMessageBrokerPublisher
    {
        Task SendAsync<T>(T item) where T : IMessageBrokerMessage;
    }
}
