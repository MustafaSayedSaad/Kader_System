﻿namespace Kader_System.Domain.DTOs.Response.Setting;

public class StGetAllMainScreensResponse : PaginationData<MainScreenData>
{
}
public class MainScreenData
{
    public int Id { get; set; }
    public required string Title { get; set; } 
    public int Main_id { get; set; }
    public required string Main_title { get; set; } 
    public string Main_image { get; set; } = string.Empty;
}

