﻿namespace Domain.Options;

//options design pattern
public class WeatherstackApi
{
    public string BaseUrl { get; set; }
    public string Key { get; set; }
    public WeatherstackApi(string baseUrl, string key)
    {
        BaseUrl = baseUrl;
        Key = key;
    }
    public WeatherstackApi()
    {
    }
}
