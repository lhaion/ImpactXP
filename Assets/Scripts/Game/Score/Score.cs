using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


public class GameScore
{
    [JsonProperty("score")]
    public float Score { get; set; }

    [JsonProperty("createdAt")]
    public CreatedAt CreatedAt { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("wallet")]
    public string Wallet { get; set; }

}

public class CreatedAt
{
    [JsonProperty("_seconds")]
    public int Seconds { get; set; }

    [JsonProperty("_nanoseconds")]
    public int Nanoseconds { get; set; }
}

