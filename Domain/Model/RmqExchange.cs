namespace Domain.Model
{
    public class RmqExchange
    {
        public string Name { get; }
        public string Vhost { get; }
        public string Type { get; }
        public bool Durable { get; }
        public bool AutoDelete { get; }
        public bool Internal { get; }

        public RmqExchange(string name, string vhost, string type, bool durable, bool autoDelete, bool intrnl)
        {
            Name = name;
            Vhost = vhost;
            Type = type;
            Durable = durable;
            AutoDelete = autoDelete;
            Internal = intrnl;
        }

        public override string ToString()
        {
            return $"Name={Name}, VHost={Vhost}, Type={Type}, Durable={Durable}, AutoDelete={AutoDelete}, Internal={Internal}";
        }
    }
}
