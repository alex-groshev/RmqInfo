using Newtonsoft.Json;

namespace DTO.Rmq
{
    [JsonObject]
    public class CapabilitiesDto
    {
        [JsonProperty(PropertyName = "publisher_confirms", Required = Required.Default)]
        public bool PublisherConfirms { get; set; }

        [JsonProperty(PropertyName = "exchange_exchange_bindings", Required = Required.Default)]
        public bool ExchangeExchangeBindings { get; set; }

        [JsonProperty(PropertyName = "basic.nack", Required = Required.Default)]
        public bool BasicNack { get; set; }

        [JsonProperty(PropertyName = "consumer_cancel_notify", Required = Required.Default)]
        public bool ConsumerCancelNotify { get; set; }

        [JsonProperty(PropertyName = "connection.blocked", Required = Required.Default)]
        public bool ConnectionBlocked { get; set; }

        [JsonProperty(PropertyName = "authentication_failure_close", Required = Required.Default)]
        public bool AuthenticationFailureClose { get; set; }
    }
}
