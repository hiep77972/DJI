using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DJIController : ApiController
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GGADPP5;Initial Catalog=DJI;Integrated Security=True");
        public DataTable LayDuLieu(string str)
        {
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter(str, con);

            DataTable tbl = new DataTable();
            sd.Fill(tbl);
            con.Close();
            return tbl;
        }
        // GET: api/DJI
        public IEnumerable<string> Get()
        {
            return new string[] { "a", "b" };
        }

        // GET: api/DJI/5
        // GET: api/DJI/5
        [HttpGet]
        public IsSuccess Get(string username, string password, string key)
        {
            IsSuccess iss = new IsSuccess();

            //[FromBody]string value
            if (key == "keyapi")
            {
                String msgError = "Có lỗi xảy ra. Vui lòng thử lại!";
                string sql = string.Format("select * from Users where Username=N'{0}' and password=N'{1}'", username, password);
                if (LayDuLieu(sql).Rows.Count < 0)
                {
                    iss.status = 1;
                    iss.message = "";
                }
                else
                {
                    iss.status = 0;
                    iss.message = "Error Database";
                }
            }
            else
            {
                iss.status = 0;
                iss.message = "Key doesn't exist";
            }
            return iss;
        }

        // POST: api/DJI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DJI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DJI/5
        public void Delete(int id)
        {
        }
    }
}
