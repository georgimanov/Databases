using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountains_Code_First.Migrations;

namespace Mountains_Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());

            var context = new MountainsContext();

            var peaks = context.Peaks.Select(p => new
            {
                Name = p.Name
            });

            Console.WriteLine(string.Join(", ", peaks));
        }
    }
}
