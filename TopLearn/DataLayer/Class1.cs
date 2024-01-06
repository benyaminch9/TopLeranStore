using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class Class1 : DbContext
    {
        public Class1(DbContextOptions<Class1> options)
            : base(options)
        {

        }


    }
}
