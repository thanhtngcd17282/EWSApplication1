﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSApplication.DataLayers.Common
{
    public class StructureComment
    {

        public bool anonymous { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public int postid { get; set; }

        public string userid { get; set; }
    }
}
