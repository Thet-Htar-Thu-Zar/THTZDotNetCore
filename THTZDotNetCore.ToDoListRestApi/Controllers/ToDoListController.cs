using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using THTZDotNetCore.ToDoListRestApi.DataModel;
using THTZDotNetCore.ToDoListRestApi.ViewModel;

namespace THTZDotNetCore.ToDoListRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=THTZDotNetCore;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetTaskCategory()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_taskCategory where DeleteFlag = 0;";

                var lst = db.Query<TaskCategoryViewModel>(query).ToList();

                return Ok(lst);
            }
        }

        [HttpPost]
        public IActionResult CreateTaskCategory(TaskCategoryDataModel Task)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_TaskCategory]
           ([TaskCategoryName]
           ,[DeleteFlag])
     VALUES
            (@TaskCategoryName
            ,0)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new TaskCategoryDataModel
                {
                    TaskCategoryId = Task.TaskCategoryId,
                    TaskCategoryName = Task.TaskCategoryName,
                });

                return Ok(result == 1 ? "Category creating successful." : "Category creating failed.");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetTaskCategoryById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_taskCategory where DeleteFlag = 0 and TaskCategoryId = @TaskCategoryId;";
                var item = db.Query<TaskCategoryViewModel>(query, new TaskCategoryViewModel
                {
                    TaskCategoryId = id,
                }).FirstOrDefault();

                if (item is null)
                {
                    return NotFound();
                };

                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskCategory(int id, TaskCategoryDataModel Task)
        {

            string query = $@"UPDATE [dbo].[Tbl_TaskCategory]
   SET [TaskCategoryName] = @TaskCategoryName
      ,[DeleteFlag] = 0
 WHERE TaskCategoryId = @TaskCategoryId ";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new TaskCategoryDataModel
                {
                    TaskCategoryId = id,
                    TaskCategoryName = Task.TaskCategoryName,
                });

                return Ok(result == 1 ? "Updating Successful" : "Updating Fail.");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PatchTaskCategory(int id, TaskCategoryViewModel Task)
        {
            string conditions = "";

            if (!string.IsNullOrEmpty(Task.TaskCategoryName))
            {
                conditions += "[TaskCategoryName] = @TaskCategoryName, ";
            }

            if (conditions.Length == 0)
            {
                return BadRequest("Invalid Parameters");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"UPDATE [dbo].[Tbl_TaskCategory] SET {conditions}
, [DeleteFlag] = 0 WHERE TaskCategoryId = @TaskCategoryId";
                int result = db.Execute(query, new TaskCategoryViewModel
                {
                    TaskCategoryId = id,
                    TaskCategoryName = Task.TaskCategoryName,
                });

                return Ok(result == 1 ? "Updating Successful" : "Updating Fail.");
            }

        }

        [HttpDelete]
        public IActionResult DeleteTaskCategory(int id)
        {
            string query = @"UPDATE [dbo].[Tbl_TaskCategory]
   SET [DeleteFlag] = 1
    WHERE TaskCategoryId = @TaskCategoryId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new TaskCategoryDataModel
                {
                    TaskCategoryId = id,

                });

                return Ok(result == 1 ? "Deleting Successful" : "Deleting Fail.");
            }
        }
    }
}
