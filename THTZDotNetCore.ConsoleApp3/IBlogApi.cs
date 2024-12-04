﻿using Refit;

namespace THTZDotNetCore.ConsoleApp3
{
    public interface IBlogApi
    {
        [Get("/api/{blogs}")]
        Task<List<BlogModel>> GetBlogs();
    }

    public class BlogModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; } = null!;
        public string BlogAuthor { get; set;} = null!;
        public string BlogContent { get; set; } = null!;
        public bool DeleteFlag { get; set;}
    }   
}