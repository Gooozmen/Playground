using System.Text.Json.Serialization;

namespace Shared.DTOs;

public class WeatherstackResponse
{
    public WeatherstackRequest Request { get; set; }
    public WeatherstackLocation Location { get; set; }
    public WeatherstackCurrent Current { get; set; }
}

public class WeatherstackRequest
{
    [JsonPropertyName("type")]
    public string Type { get; set; } 
    [JsonPropertyName("query")]
    public string Query { get; set; } 
    [JsonPropertyName("language")]
    public string Language { get; set; } 
    [JsonPropertyName("unit")]
    public string Unit { get; set; } 
}

public class WeatherstackLocation
{
    [JsonPropertyName("name")]
    public string Name { get; set; } 
    [JsonPropertyName("country")]
    public string Country { get; set; }
    [JsonPropertyName("region")]
    public string Region { get; set; }
    [JsonPropertyName("lat")]
    public string Lat { get; set; } 
    [JsonPropertyName("lon")]
    public string Lon { get; set; } 
    [JsonPropertyName("timezone_id")]
    public string TimezoneId { get; set; } 
    [JsonPropertyName("localtime")]
    public string Localtime { get; set; } 
    [JsonPropertyName("localtime_epoch")]
    public long LocaltimeEpoch { get; set; }
    [JsonPropertyName("utc_offset")]
    public string UtcOffset { get; set; } 
}

public class WeatherstackCurrent
{
    [JsonPropertyName("observation_time")]
    public string ObservationTime { get; set; } 
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }
    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }
    [JsonPropertyName("weather_icons")]
    public List<string> WeatherIcons { get; set; }
    [JsonPropertyName("weather_descriptions")]
    public List<string> WeatherDescriptions { get; set; }
    [JsonPropertyName("wind_speed")]
    public int WindSpeed { get; set; } = 0;
    [JsonPropertyName("wind_degree")]
    public int WindDegree { get; set; }
    [JsonPropertyName("wind_dir")]
    public string WindDir { get; set; } 
    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }
    [JsonPropertyName("precip")]
    public double Precip { get; set; }
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
    [JsonPropertyName("cloudover")]
    public int Cloudcover { get; set; }
    [JsonPropertyName("feelslike")]
    public int Feelslike { get; set; }
    [JsonPropertyName("uv_index")]
    public int UvIndex { get; set; }
    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }
    [JsonPropertyName("is_day")]
    public string IsDay { get; set; } 
}

public class WeatherstackError
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("error")]
    public WeatherError Error { get; set; }
}

public class WeatherError
{
    [JsonPropertyName("code")]
    public int Code { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("info")]
    public string Info { get; set; }
}

