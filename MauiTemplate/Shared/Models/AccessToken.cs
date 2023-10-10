using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class AccessToken
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Token { get; set; }
    }
}
