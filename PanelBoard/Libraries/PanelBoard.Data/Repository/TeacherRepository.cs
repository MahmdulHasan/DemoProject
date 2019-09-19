using Microsoft.EntityFrameworkCore;
using PanelBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Repository
{
    public class TeacherRepository
                : Repository<Teacher>
    {
        public TeacherRepository(DbContext context)
            : base(context)
        {

        }
    }
}
