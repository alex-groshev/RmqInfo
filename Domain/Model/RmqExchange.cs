namespace Domain.Model
{
    public class RmqExchange
    {
        public string Name { get; private set; }

        public string Vhost { get; private set; }

        public string Type { get; private set; }

        public bool Durable { get; private set; }

        public bool AutoDelete { get; private set; }

        public bool Internal { get; private set; }

        public static Builder GetBuilder()
        {
            return new Builder();
        }

        public override string ToString()
        {
            return $"Name={Name}, VHost={Vhost}, Type={Type}, Durable={Durable}, AutoDelete={AutoDelete}, Internal={Internal}";
        }

        private RmqExchange() { }

        private void SetName(string name)
        {
            Name = name;
        }

        private void SetVhost(string vhost)
        {
            Vhost = vhost;
        }

        private void SetType(string type)
        {
            Type = type;
        }

        private void SetDurable(bool durable)
        {
            Durable = durable;
        }

        private void SetAutoDelete(bool autoDelete)
        {
            AutoDelete = autoDelete;
        }

        private void SetInternal(bool intrnl)
        {
            Internal = intrnl;
        }
        
        public class Builder
        {
            private readonly RmqExchange _result = new RmqExchange();

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

            public Builder WithType(string type)
            {
                _result.SetType(type);
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

            public Builder WithInternal(bool intrnl)
            {
                _result.SetInternal(intrnl);
                return this;
            }

            public RmqExchange Build()
            {
                return _result;
            }
        }
    }
}
