using Newtonsoft.Json;

namespace DTO.Rmq
{
    [JsonObject]
    public class ClientPropertiesDto
    {
        [JsonProperty(PropertyName = "product", Required = Required.Default)]
        public string Product { get; set; }

        [JsonProperty(PropertyName = "version", Required = Required.Default)]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "platform", Required = Required.Default)]
        public string Platform { get; set; }

        [JsonProperty(PropertyName = "copyright", Required = Required.Default)]
        public string Copyright { get; set; }

        [JsonProperty(PropertyName = "information", Required = Required.Default)]
        public string Information { get; set; }

        [JsonProperty(PropertyName = "capabilities", Required = Required.Default)]
        public CapabilitiesDto Capabilities { get; set; }

        [JsonProperty(PropertyName = "connection_name", Required = Required.Default)]
        public string ConnectionName { get; set; }
    }
}
