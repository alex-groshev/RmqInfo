using Newtonsoft.Json;

namespace DTO.Rmq
{
    [JsonObject]
    public class GarbageCollectionDto
    {
        [JsonProperty(PropertyName = "min_bin_vheap_size", Required = Required.Default)]
        public long MinBinVheapSize { get; set; }

        [JsonProperty(PropertyName = "min_heap_size", Required = Required.Default)]
        public long MinHeapSize { get; set; }

        [JsonProperty(PropertyName = "fullsweep_after", Required = Required.Default)]
        public long FullsweepAfter { get; set; }

        [JsonProperty(PropertyName = "minor_gcs", Required = Required.Default)]
        public long MinorGcs { get; set; }
    }
}
