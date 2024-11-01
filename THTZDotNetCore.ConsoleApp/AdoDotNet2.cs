using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THTZDotNetCore.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace THTZDotNetCore.ConsoleApp
{
    internal class AdoDotNet2
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=THTZDotNetCore;User ID=sa;Password=sasa@123;";
        private readonly AdoDotNetService _adoDotNetService;

        public AdoDotNet2()
        {
            _adoDotNetService = new AdoDotNetService(_connectionString);
        }

        public void Read()
        {
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";
            var dt = _adoDotNetService.Query(query);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);

            }
        }

        public void Edit()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine()!;

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";

            var dt = _adoDotNetService.Query(query, new SqlParameterModel("@BlogId", id));

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        public void Create() 
        {
            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
            (@BlogTitle
            ,@BlogAuthor
            ,@BlogContent
            ,0)
            ";

            int result = _adoDotNetService.Execute(query,
                new SqlParameterModel("@BlogTitle", title),
                new SqlParameterModel("@BlogAuthor", author),
                new SqlParameterModel("@BlogContent", content));

            Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Fail.");
        }

        public void Update()
        {
            Console.WriteLine("Blog Id: ");
            string id = Console.ReadLine();

            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId";

           
            int result = _adoDotNetService.Execute(query,
                new SqlParameterModel("@BlogId", id),
                new SqlParameterModel("@BlogTitle", title),
                new SqlParameterModel("@BlogAuthor", author),
                new SqlParameterModel("@BlogContent", content));

            Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Fail.");
        }

        public void Delete()
        {
            Console.WriteLine("Blog Id: ");
            string id = Console.ReadLine();


            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [DeleteFlag] = 1
    WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,
                new SqlParameterModel("@BlogId", id));

            if (result == 0)
            {
                Console.WriteLine("Deleting Fail.");
            }
            else
            {
                Console.WriteLine("Deleting Success.");
            }

        }
    }
}
