using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Kolo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolo.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class PlayerTeamController : ControllerBase
    {
        [HttpPost("{IdTeam}/players}")]

        public IActionResult AssignPlayer(Player request)
        {
            using (var con = new SqlConnection("data source=db-mssql;initial catalog=s16479;integrated security=true;MultipleActiveResultSets=true"))
            using (var com = new SqlCommand())
            {
                
            }
                return null;
        }


    }
}
