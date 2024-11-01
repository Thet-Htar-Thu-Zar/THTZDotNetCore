using Dapper;
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
        public IActionResult GetToDoList()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT [TaskId]
      ,[TaskName]
      ,[TaskDescription]
      ,[TaskCategoryId]
      ,[PriorityLevel]
      ,[Status]
      ,[CreatedDate]
      ,[DueDate]
      ,[CompletedDate]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_ToDoList] where DeleteFlag = 0;";

                var lst = db.Query<ToDoListViewModel>(query).ToList();

                return Ok(lst);
            }
        }

        [HttpPost]
        public IActionResult CreateToDoList(ToDoListDataModel list)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_ToDoList]
           ([TaskName]
           ,[TaskDescription]
           ,[TaskCategoryId]
           ,[PriorityLevel]
           ,[Status]
           ,[CreatedDate]
           ,[DueDate]
           ,[CompletedDate]
            ,[DeleteFlag])
     VALUES
            (@TaskName
            ,@TaskDescription
            ,@TaskCategoryId
            ,@PriorityLevel
            ,@Status
            ,@CreatedDate
            ,@DueDate
            ,@CompletedDate
            ,0)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new ToDoListDataModel
                {
                    TaskName = list.TaskName,
                    TaskDescription = list.TaskDescription,
                    TaskCategoryId = list.TaskCategoryId,
                    PriorityLevel = list.PriorityLevel,
                    Status = list.Status,
                    CreatedDate = list.CreatedDate,
                    DueDate = list.DueDate,
                    CompletedDate = list.CompletedDate
                });

                return Ok(result == 1 ? "ToDoList creating successful." : "ToDoList creating failed.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetToDoListById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_todolist where DeleteFlag = 0 and TaskId = @TaskId;";
                var item = db.Query<ToDoListViewModel>(query, new ToDoListViewModel
                {
                    TaskId = id,
                }).FirstOrDefault();

                if (item is null)
                {
                    return NotFound();
                };

                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskCategory(int id, ToDoListDataModel list)
        {

            string query = $@"UPDATE [dbo].[Tbl_ToDoList]
   SET [TaskName] = @TaskName
      ,[TaskDescription] = @TaskDescription
      ,[TaskCategoryId] = @TaskCategoryId
      ,[PriorityLevel] = @PriorityLevel
      ,[Status] = @Status
      ,[CreatedDate] = @CreatedDate
      ,[DueDate] = @DueDate
      ,[CompletedDate] = @CompletedDate
 WHERE TaskId = @TaskId ";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new ToDoListDataModel
                {
                    TaskId = id,
                    TaskName = list.TaskName,
                    TaskDescription = list.TaskDescription,
                    TaskCategoryId = list.TaskCategoryId,
                    PriorityLevel = list.PriorityLevel,
                    Status = list.Status,
                    CreatedDate = list.CreatedDate,
                    DueDate = list.DueDate,
                    CompletedDate = list.CompletedDate
                });

                return Ok(result == 1 ? "Updating Successful" : "Updating Fail.");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PatchToDoList(int id, ToDoListViewModel list)
        {
            string conditions = "";

            if (!string.IsNullOrEmpty(list.TaskName))
            {
                conditions += "[TaskName] = @TaskName, ";
            }
            if (!string.IsNullOrEmpty(list.TaskDescription))
            {
                conditions += "[TaskDescription] = @TaskDescription, ";
            }
            if (0 != list.TaskCategoryId)
            {
                conditions += "[TaskCategoryId] = @TaskCategoryId, ";
            }
            if (0 != list.PriorityLevel)
            {
                conditions += "[PriorityLevel] = @PriorityLevel, ";
            }
            if (!string.IsNullOrEmpty(list.Status))
            {
                conditions += "[Status] = @Status, ";
            }
            if (null != (list.CreatedDate))
            {
                conditions += "[CreatedDate] = @CreatedDate, ";
            }
            if (null != (list.DueDate))
            {
                conditions += "[DueDate] = @DueDate, ";
            }
            if (null != (list.CompletedDate))
            {
                conditions += "[CompletedDate] = @CompletedDate, ";
            }

            if (conditions.Length == 0)
            {
                return BadRequest("Invalid Parameters");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"UPDATE [dbo].[Tbl_ToDoList] SET {conditions}
, [DeleteFlag] = 0 WHERE TaskId = @TaskId";
                int result = db.Execute(query, new ToDoListViewModel
                {
                    TaskId = id,
                    TaskName = list.TaskName,
                    TaskDescription = list.TaskDescription,
                    TaskCategoryId = list.TaskCategoryId,
                    PriorityLevel = list.PriorityLevel,
                    Status = list.Status,
                    CreatedDate = list.CreatedDate,
                    DueDate = list.DueDate,
                    CompletedDate = list.CompletedDate
                });

                return Ok(result == 1 ? "Updating Successful" : "Updating Fail.");
            }

        }

        [HttpDelete]
        public IActionResult DeleteToDoList(int id)
        {
            string query = @"UPDATE [dbo].[Tbl_ToDoList]
   SET [DeleteFlag] = 1
    WHERE TaskId = @TaskId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new ToDoListDataModel
                {
                    TaskId = id,

                });

                return Ok(result == 1 ? "Deleting Successful" : "Deleting Fail.");
            }
        }
    }
}
