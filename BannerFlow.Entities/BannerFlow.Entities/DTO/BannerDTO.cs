﻿using System;

namespace BannerFlow.Entities
{
    public class BannerDTO
    {
        public int Id { get; set; }
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
