namespace Domain.Model
{
    public class RmqQueue
    {
        public string Name { get; private set; }

        public string Vhost { get; private set; }

        public bool Durable { get; private set; }

        public bool AutoDelete { get; private set; }

        public bool Exclusive { get; private set; }

        public static Builder GetBuilder()
        {
            return new Builder();
        }

        public override string ToString()
        {
            return $"Name={Name}, VHost={Vhost}, Durable={Durable}, AutoDelete={AutoDelete}, Exclusive={Exclusive}";
        }

        private RmqQueue() { }

        private void SetName(string name)
        {
            Name = name;
        }

        private void SetVhost(string vhost)
        {
            Vhost = vhost;
        }

        private void SetDurable(bool durable)
        {
            Durable = durable;
        }

        private void SetAutoDelete(bool autoDelete)
        {
            AutoDelete = autoDelete;
        }

        private void SetExclusive(bool exclusive)
        {
            Exclusive = exclusive;
        }

        public class Builder
        {
            private readonly RmqQueue _result = new RmqQueue();

            public Builder WithName(string name)
            {
                _result.SetName(name);
                return this;
            }

            public Builder WithVhost(string vhost)
            {
                _result.SetVhost(vhost);
                return this;
            }

            public Builder WithDurable(bool durable)
            {
                _result.SetDurable(durable);
                return this;
            }

            public Builder WithAutoDelete(bool autoDelete)
            {
                _result.SetAutoDelete(autoDelete);
                return this;
            }

            public Builder WithExclusive(bool exclusive)
            {
                _result.SetExclusive(exclusive);
                return this;
            }

            public RmqQueue Build()
            {
                return _result;
            }
        }
    }
}
