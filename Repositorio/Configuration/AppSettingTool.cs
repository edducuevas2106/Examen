using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Configuration
{
    public class AppSettingTool
    {
        private readonly IConfiguration _configuration = null;
        public AppSettingTool(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString => _configuration.GetConnectionString("localDb");
    }
}
