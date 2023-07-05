﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StudentImage : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
