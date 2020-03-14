﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class HeadingLang
    {
        public int HeadingId { get; set; }
        public Heading Heading { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public int LangId { get; set; }
        public Language Lang { get; set; }
    }
}
