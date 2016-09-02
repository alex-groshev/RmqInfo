using Newtonsoft.Json;

namespace DTO.Rmq
{
    public class ExchangeDto
    {
        [JsonProperty(PropertyName = "name", Required = Required.Default)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "vhost", Required = Required.Default)]
        public string Vhost { get; set; }

        [JsonProperty(PropertyName = "type", Required = Required.Default)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "durable", Required = Required.Default)]
        public bool Durable { get; set; }

        [JsonProperty(PropertyName = "auto_delete", Required = Required.Default)]
        public bool AutoDelete { get; set; }

        [JsonProperty(PropertyName = "internal", Required = Required.Default)]
        public bool Internal { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "arguments", Required = Required.AllowNull)]
        public object Arguments { get; set; }
    }
}
