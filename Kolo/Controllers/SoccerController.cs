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
    [Route("api/championships")]
    [ApiController]
    public class SoccerController : ControllerBase
    {

        [HttpGet("{IdChampionship}/teams}")]
        public IActionResult GetTeams(int IdChampionship)
        {
            List<Team> TeamList = new List<Team>();


            using (var con = new SqlConnection("data source=db-mssql;initial catalog=s16479;integrated security=true;MultipleActiveResultSets=true"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    //1.Czy zawody istnieja?

                    com.CommandText = "select IdChampionship from Championship";
                    com.Transaction = tran;
                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        tran.Rollback();
                        return BadRequest("Takie zawody sie nie odbyly");
                    }
                    int idChampionship = (int)dr["IdChampionship"];
                    dr.Close();

                    com.CommandText = "select e.IdTeam, e.TeamName, t.Score from  Championship c inner join Championship_Team t on  c.IdChampionship = t.IdChampionship inner join Team e on t.IdTeam = e.IdTeam where e.IdChampionship=@IdChampionship order by t.Score";
                    com.Parameters.AddWithValue("IdChampionship", idChampionship);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {

                        var team = new Team();
                        team.Id = (int)dr["IdTeam"];
                        team.Name = dr["TeamName"].ToString();
                        team.Score = (float)dr["Score"];
                        TeamList.Add(team);

                    }
                    dr.Close();

                    tran.Commit();
                    return Ok(TeamList);


                }
                catch (SqlException exception)
                {
                    tran.Rollback();
                    return BadRequest("Blad: " + exception);
                }

            }
        }
    }
}
