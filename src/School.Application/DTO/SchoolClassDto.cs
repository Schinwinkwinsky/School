﻿using School.Domain.Entities;

namespace School.Application.DTO
{
    public class SchoolClassDto : IDto<SchoolClass>
    {
        public int Id { get; set; }

        public void CopyToEntity(SchoolClass item)
        {
            throw new NotImplementedException();
        }
    }
}
