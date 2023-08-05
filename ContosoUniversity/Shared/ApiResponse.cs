using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Shared
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string Message = string.Empty;
        public bool Success { get; set; } = true;
    }
}
