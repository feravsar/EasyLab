using System;
using EasyLab.Core.Entities;
using EasyLab.Core.Specifications;

namespace EasyLab.Core.Specifications
{
    public sealed class CourseSpecification : BaseSpecification<Course>
    {
        public CourseSpecification(Guid courseId) : base(u => u.Id == courseId)
        {          
            AddInclude(t=>t.Users);     
        }
    }
}
