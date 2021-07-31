using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSDelivrCLI.Models
{
    public class PackageVersion
    {
        public PackageVersion()
        {
            Versions = new List<string>();
        }

        [JsonPropertyName("tags")]
        public PackageTag Tag { get; set; }

        [JsonPropertyName("versions")]
        public List<string> Versions { get; set; }
    }
}