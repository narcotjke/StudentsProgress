using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace WebUI.Models
{
    public class SearchOptionsModel
    {
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int GroupNumber { get; set; }
        public int Speciality { get; set; }
        [Range(4, 10)]
        public double Progress { get; set; }
        [Range(1, int.MaxValue)]
        public int RecordBookNumber { get; set; }

        public List<Speciality> Specialities;

        public SearchOptionsModel()
        {
            Specialities = new List<Speciality>();
        }
    }
}