﻿using System.Collections.Generic;
using System.Web;

namespace MiniAbp.Domain.Entitys
{
    public class FileInput
    {
        public List<HttpPostedFile> Files { get; set; }
    }
}