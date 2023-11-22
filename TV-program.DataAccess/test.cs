using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TV_program.DataAccess;

namespace TV_program.DataAccess
{
    public class Test
    {
        public void test(IDbContextFactory<TV_programDbContext> contextFactory)
        {
            using var context = contextFactory.CreateDbContext();
            context.User.Add(new Entities.UserEntity() { });
            context.User.Where(x => x.Id == 1);
            context.SaveChanges();
        }
    }
}
