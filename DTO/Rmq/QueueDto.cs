using System;
using Newtonsoft.Json;

namespace DTO.Rmq
{
    public class QueueDto
    {
        [JsonProperty(PropertyName = "memory", Required = Required.Default)]
        public long Memory { get; set; }

        [JsonProperty(PropertyName = "reductions", Required = Required.Default)]
        public long Reductions { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "reductions_details", Required = Required.AllowNull)]
        public object ReductionsDetails { get; set; }

        [JsonProperty(PropertyName = "messages", Required = Required.Default)]
        public long Messages { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "messages_details", Required = Required.AllowNull)]
        public object MessagesDetails { get; set; }

        [JsonProperty(PropertyName = "messages_ready", Required = Required.Default)]
        public long MessagesReady { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "messages_ready_details", Required = Required.AllowNull)]
        public object MessagesReadyDetails { get; set; }

        [JsonProperty(PropertyName = "messages_unacknowledged", Required = Required.Default)]
        public long MessagesUnacknowledged { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "messages_unacknowledged_details", Required = Required.AllowNull)]
        public object MessagesUnacknowledgedDetails { get; set; }

        [JsonProperty(PropertyName = "idle_since", Required = Required.Default)]
        public DateTime IdleSince { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "consumer_utilisation", Required = Required.AllowNull)]
        public object ConsumerUtilisation { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "policy", Required = Required.AllowNull)]
        public object Policy { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "exclusive_consumer_tag", Required = Required.AllowNull)]
        public object ExclusiveConsumerTag { get; set; }

        [JsonProperty(PropertyName = "consumers", Required = Required.Default)]
        public long Consumers { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "recoverable_slaves", Required = Required.AllowNull)]
        public object RecoverableSlaves { get; set; }

        [JsonProperty(PropertyName = "state", Required = Required.Default)]
        public string State { get; set; }

        [JsonProperty(PropertyName = "garbage_collection", Required = Required.Default)]
        public GarbageCollectionDto GarbageCollection { get; set; }

        [JsonProperty(PropertyName = "messages_ram", Required = Required.Default)]
        public long MessagesRam { get; set; }

        [JsonProperty(PropertyName = "messages_ready_ram", Required = Required.Default)]
        public long MessagesReadyRam { get; set; }

        [JsonProperty(PropertyName = "messages_unacknowledged_ram", Required = Required.Default)]
        public long MessagesUnacknowledgedRam { get; set; }

        [JsonProperty(PropertyName = "messages_persistent", Required = Required.Default)]
        public long MessagesPersistent { get; set; }

        [JsonProperty(PropertyName = "message_bytes", Required = Required.Default)]
        public long MessageBytes { get; set; }

        [JsonProperty(PropertyName = "message_bytes_ready", Required = Required.Default)]
        public long MessageBytesReady { get; set; }

        [JsonProperty(PropertyName = "message_bytes_unacknowledged", Required = Required.Default)]
        public long MessageBytesUnacknowledged { get; set; }

        [JsonProperty(PropertyName = "message_bytes_ram", Required = Required.Default)]
        public long MessageBytesRam { get; set; }

        [JsonProperty(PropertyName = "message_bytes_persistent", Required = Required.Default)]
        public long MessageBytesPersistent { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "head_message_timestamp", Required = Required.AllowNull)]
        public object HeadMessageTimestamp { get; set; }

        [JsonProperty(PropertyName = "disk_reads", Required = Required.Default)]
        public long DiskReads { get; set; }

        [JsonProperty(PropertyName = "disk_writes", Required = Required.Default)]
        public long DiskWrites { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "backing_queue_status", Required = Required.AllowNull)]
        public object BackingQueueStatus { get; set; }

        [JsonProperty(PropertyName = "node", Required = Required.Default)]
        public string Node { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "arguments", Required = Required.AllowNull)]
        public object Arguments { get; set; }

        [JsonProperty(PropertyName = "exclusive", Required = Required.Default)]
        public bool Exclusive { get; set; }

        [JsonProperty(PropertyName = "auto_delete", Required = Required.Default)]
        public bool AutoDelete { get; set; }

        [JsonProperty(PropertyName = "durable", Required = Required.Default)]
        public bool Durable { get; set; }

        [JsonProperty(PropertyName = "vhost", Required = Required.Default)]
        public string Vhost { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Default)]
        public string Name { get; set; }
    }
}
