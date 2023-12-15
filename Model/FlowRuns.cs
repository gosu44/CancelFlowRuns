// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

namespace FlowRuns.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Correlation
    {
        [JsonProperty("clientTrackingId")]
        public string ClientTrackingId { get; set; }
    }

    public class ContentHash
    {
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class TriggerInputsLink
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("contentVersion")]
        public string ContentVersion { get; set; }

        [JsonProperty("contentSize")]
        public int ContentSize { get; set; }

        [JsonProperty("contentHash")]
        public ContentHash ContentHash { get; set; }
    }

    public class OutputsLink
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("contentVersion")]
        public string ContentVersion { get; set; }

        [JsonProperty("contentSize")]
        public int ContentSize { get; set; }

        [JsonProperty("contentHash")]
        public ContentHash ContentHash { get; set; }
    }

    public class Trigger
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inputsLink")]
        public TriggerInputsLink InputsLink { get; set; }

        [JsonProperty("outputsLink")]
        public OutputsLink OutputsLink { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty("originHistoryName")]
        public string OriginHistoryName { get; set; }

        [JsonProperty("correlation")]
        public Correlation Correlation { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Properties
    {
        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("correlation")]
        public Correlation Correlation { get; set; }

        [JsonProperty("trigger")]
        public Trigger Trigger { get; set; }
    }

    public class Value
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

    public class FlowRuns
    {
        [JsonProperty("value")]
        public List<Value> Value { get; set; }

        public string NextLink { get; set; }
    }

}

