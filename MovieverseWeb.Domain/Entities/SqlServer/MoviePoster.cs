﻿namespace MovieverseWeb.Domain.Entities.SqlServer
{
    public class MoviePoster : EntityBase
    {
        public string? Link { get; set; }
        public double? AspectRatio { get; set; }
        public string? Language { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public Guid EntertainmentId { get; set; }
    }
}
