﻿namespace THTZDotNetCore.RestApi.DataModel
{
    public class BlogDataModel
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
        public bool DeleteFlag { get; set; }

    }
}
