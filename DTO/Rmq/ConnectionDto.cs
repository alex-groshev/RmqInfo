using Newtonsoft.Json;

namespace DTO.Rmq
{
    public class ConnectionDto
    {
        [JsonProperty(PropertyName = "connected_at", Required = Required.Default)]
        public double ConnectedAt { get; set; }

        [JsonProperty(PropertyName = "client_properties", Required = Required.Default)]
        public ClientPropertiesDto ClientProperties { get; set; }

        [JsonProperty(PropertyName = "channel_max", Required = Required.Default)]
        public int ChannelMax { get; set; }

        [JsonProperty(PropertyName = "frame_max", Required = Required.Default)]
        public long FrameMax { get; set; }

        [JsonProperty(PropertyName = "timeout", Required = Required.Default)]
        public int Timeout { get; set; }

        [JsonProperty(PropertyName = "vhost", Required = Required.Default)]
        public string Vhost { get; set; }

        [JsonProperty(PropertyName = "user", Required = Required.Default)]
        public string User { get; set; }

        [JsonProperty(PropertyName = "protocol", Required = Required.Default)]
        public string Protocol { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "ssl_hash", Required = Required.AllowNull)]
        public object SslHash { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "ssl_cipher", Required = Required.AllowNull)]
        public object SslCipher { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "ssl_key_exchange", Required = Required.AllowNull)]
        public object SslKeyExchange { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "ssl_protocol", Required = Required.AllowNull)]
        public object SslProtocol { get; set; }

        [JsonProperty(PropertyName = "auth_mechanism", Required = Required.AllowNull)]
        public string AuthMechanism { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "peer_cert_validity", Required = Required.AllowNull)]
        public object PeerCertValidity { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "peer_cert_issuer", Required = Required.AllowNull)]
        public object PeerCertIssuer { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "peer_cert_subject", Required = Required.AllowNull)]
        public object PeerCertSubject { get; set; }
        
        [JsonProperty(PropertyName = "ssl", Required = Required.Default)]
        public bool Ssl { get; set; }

        [JsonProperty(PropertyName = "peer_host", Required = Required.Default)]
        public string PeerHost { get; set; }

        [JsonProperty(PropertyName = "host", Required = Required.Default)]
        public string Host { get; set; }

        [JsonProperty(PropertyName = "peer_port", Required = Required.Default)]
        public int PeerPort { get; set; }

        [JsonProperty(PropertyName = "port", Required = Required.Default)]
        public int Port { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Default)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "node", Required = Required.Default)]
        public string Node { get; set; }

        [JsonProperty(PropertyName = "type", Required = Required.Default)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "garbage_collection", Required = Required.Default)]
        public GarbageCollectionDto GarbageCollection { get; set; }

        [JsonProperty(PropertyName = "reductions", Required = Required.Default)]
        public int Reductions { get; set; }

        [JsonProperty(PropertyName = "channels", Required = Required.Default)]
        public int Channels { get; set; }

        [JsonProperty(PropertyName = "state", Required = Required.Default)]
        public string State { get; set; }

        [JsonProperty(PropertyName = "send_pend", Required = Required.Default)]
        public int SendPend { get; set; }

        [JsonProperty(PropertyName = "send_cnt", Required = Required.Default)]
        public int SendCnt { get; set; }

        [JsonProperty(PropertyName = "recv_cnt", Required = Required.Default)]
        public int RecvCnt { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "recv_oct_details", Required = Required.AllowNull)]
        public object RecvOctDetails { get; set; }

        [JsonProperty(PropertyName = "recv_oct", Required = Required.Default)]
        public int RecvOct { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "send_oct_details", Required = Required.AllowNull)]
        public object SendOctDetails { get; set; }

        [JsonProperty(PropertyName = "send_oct", Required = Required.Default)]
        public int SendOct { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "reductions_details", Required = Required.AllowNull)]
        public object ReductionsDetails { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "reductions", Required = Required.AllowNull)]
        public object Discard1 { get; set; }
    }
}
