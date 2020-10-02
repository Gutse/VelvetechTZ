﻿using System.Collections.Generic;
using VelvetechTZ.Domain.EFRelated;
using VelvetechTZ.Domain.Student;

namespace VelvetechTZ.Domain.Group
{
    public class GroupModel: BaseModel.BaseModel
    {
        public virtual string? Name { get; set; }
        public virtual List<StudentGroup>? Students { get; set; }
    }
}
