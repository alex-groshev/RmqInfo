using System;

namespace Domain.Model
{
    public class RmqConnectionStatus
    {
        public DateTime ConnectedAt { get; private set; }
        public string State { get; private set; }

        public RmqConnectionStatus(DateTime connectedAt, string state)
        {
            ConnectedAt = connectedAt;
            State = state;
        }
    }
}
