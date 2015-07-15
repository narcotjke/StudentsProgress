﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class SubjectViewModel
    {
        public int SubjectID { get; set; }
        [Required, StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [Required, StringLength(256, MinimumLength = 4)]
        public string Description { get; set; }
    }
}