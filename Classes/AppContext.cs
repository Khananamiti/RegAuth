using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SemestrV
{
    internal class AppContext : DbContext /* Наследование */
    {
        public DbSet<User> Users { get; set; } /* Список из таблиц на основе модели User */
        public DbSet<Order> Orders { get; set; } /* Список из таблиц на основе модели Orders */

        public AppContext() : base("DefaultConnection") { } /* Название подключения к БД */
    }
}
