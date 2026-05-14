using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Khodzhiev.Classes.Database
{
    public class Config
    {
        public static readonly string Connection = "server=localhost;uid=root;password=;database=TaskManager;;";
        public static readonly MySqlServerVersion Version = new MySqlServerVersion(new Version(8, 0, 32));
    }
}
