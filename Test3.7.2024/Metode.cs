using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;

namespace Test3._7._2024
{
    public class Inventar
    {
        public int ID { get; set; }
        public DateTime BackupDate { get; set; }
        public string? Applications { get; set; }
    }
    public struct Log
    {
        public int IDlog { get; set; }
        public string User { get; set; }
        public DateTime LogDate { get; set; }
        public int InvIdOperatedOn { get; set; }
        public string TypeOfOperationUsed { get; set; }

    }

    // Structură pentru a stoca informațiile despre fiecare element din ListBox
    public struct ListBoxItem(string text, Color color)
    {
        public string Text = text;
        public Color Color = color;

        public override readonly string ToString() => Text;
    }

    public enum OperationType { Add, Delete, Update }
    public class Operation
    {
        public OperationType Type { get; set; }
        public required Inventar Item { get; set; }
    }


    public class Metode
    {
        // String-urile de conectare la DB necesare
        readonly string conUseriString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Useri;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        readonly string conInventarString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Inventar;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Verificare date login
        public int VerifyLogin(string user, string pass)
        {
            using SqlConnection conexiune = new(conUseriString);
            conexiune.Open();
            bool status = pass.Equals(conexiune.QueryFirstOrDefault<string>("Select [Password] FROM dbo.Users WHERE Username = @username", new { username = user }));
            int type = 0;
            if (status) { type = conexiune.QueryFirstOrDefault<int>("Select [Drepturi] FROM dbo.Users WHERE Username = @username", new { username = user }); }
            conexiune.Close();
            return type;
        }

        // Search interval data back-up
        public List<Inventar> SearchByDate(DateTime startDate, DateTime endDate)
        {
            using SqlConnection conexiune = new(conInventarString);
            conexiune.Open();
            var result = conexiune.Query<Inventar>("Select * FROM dbo.Items WHERE [Backup] >= @startDate AND [Backup] <= @endDate", new { startDate, endDate });
            if (result == null || !result.Any()) { return []; }
            foreach (Inventar inv in result)
            {
                inv.BackupDate = conexiune.Query<DateTime>("Select [Backup] FROM dbo.Items WHERE ID = " + inv.ID).Last();
                inv.Applications = conexiune.Query<string>("Select [Aplicatii] FROM dbo.Items WHERE Id = " + inv.ID).Last();
            }
            conexiune.Close();
            return result.ToList();
        }

        // Search dupa ID
        public List<Inventar> SearchByID(int id)
        {
            using SqlConnection conexiune = new(conInventarString);
            conexiune.Open();
            var result = conexiune.Query<Inventar>("Select * FROM dbo.Items WHERE Id = @id", new { id });
            if (result == null || !result.Any()) { return []; }
            result.First().BackupDate = conexiune.Query<DateTime>("Select [Backup] FROM dbo.Items WHERE Id = " + result.First().ID).Last();
            result.First().Applications = conexiune.Query<string>("Select [Aplicatii] FROM dbo.Items WHERE Id = " + result.First().ID).Last();
            conexiune.Close();
            return result.ToList();
        }

        // Search dupa aplicatii
        public List<Inventar> SearchByApp(string app)
        {
            using SqlConnection conexiune = new(conInventarString);
            conexiune.Open();
            var result = conexiune.Query<Inventar>("Select * FROM dbo.Items WHERE [Aplicatii] = @app", new { app });
            if (app != null && app !="")
            {
                result = conexiune.Query<Inventar>("Select * FROM dbo.Items WHERE [Aplicatii] LIKE '%'+@app+'%'", new { app });
            }

            if (result == null || !result.Any()) { return []; }
            foreach (Inventar inv in result)
            {
                inv.BackupDate = conexiune.Query<DateTime>("Select [Backup] FROM dbo.Items WHERE ID = " + inv.ID).Last();
                inv.Applications = conexiune.Query<string>("Select [Aplicatii] FROM dbo.Items WHERE Id = " + inv.ID).Last();
            }
            conexiune.Close();
            return result.ToList();
        }

        // Metoda de add new cu auto-incrementare ID
        public void AddNewInventar(ref Inventar inventar)
        {
            using SqlConnection connection = new(conInventarString);
            connection.Open();
            if (inventar.ID == 0)
            {
                // Get the maximum ID from the database
                SqlCommand getMaxIdCommand = new("SELECT MAX(ID) FROM dbo.Items", connection);
                var maxIdObj = getMaxIdCommand.ExecuteScalar();
                int maxId = maxIdObj == DBNull.Value ? 0 : Convert.ToInt32(maxIdObj);
                int newId = maxId + 1;
                inventar.ID = newId;
            }
            // Insert the new inventory item with the generated ID
            SqlCommand insertCommand = new("INSERT INTO items ([Id], [backup], [Aplicatii]) VALUES (@id, @backupDate, @applications)", connection);
            insertCommand.Parameters.AddWithValue("@id", inventar.ID);
            insertCommand.Parameters.AddWithValue("@backupDate", inventar.BackupDate);
            insertCommand.Parameters.AddWithValue("@applications", inventar.Applications);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        // Metoda de Update a obiectului din inventar
        public void UpdateInventar(Inventar inventar)
        {
            using SqlConnection connection = new(conInventarString);
            connection.Open();
            connection.Execute("Update dbo.items SET [backup] = @BackupDate, [Aplicatii] = @Applications WHERE ID = @ID", inventar);
            connection.Close();
        }

        // Metoda de Delete a unui device dupa id-ul dorit
        public void DeleteInventar(int id)
        {
            using SqlConnection connection = new(conInventarString);
            connection.Open();
            connection.Execute("Delete from dbo.items WHERE ID = @id", new { id });
            connection.Close();
        }
        public Inventar SelectInventar(int id)
        {
            using SqlConnection connection = new(conInventarString);
            connection.Open();
            var inv = connection.Query<Inventar>("Select * FROM dbo.Items WHERE Id = @id", new { id }).FirstOrDefault();

            if (inv != null)
            {
                inv.BackupDate = connection.Query<DateTime>("Select [Backup] FROM dbo.Items WHERE Id = " + inv.ID).Last();
                inv.Applications = connection.Query<string>("Select [Aplicatii] FROM dbo.Items WHERE Id = " + inv.ID).Last();
                connection.Close();
                return inv;
            }
            else
            {
                connection.Close();
                return new Inventar();
            }
        }

        // Extrag intr-o lista de int-uri ID-urile device-urilor din DB
        public List<int> GetIdsFromDatabase()
        {
            using SqlConnection connection = new(conInventarString);
            connection.Open();
            string query = "SELECT ID FROM dbo.items";
            List<int> ids = connection.Query<int>(query).AsList();
            connection.Close();
            return ids;
        }
        public void LogToDB(Log info)
        {
            using SqlConnection connection = new(conUseriString);
            connection.Open();

            // Get the maximum ID from the database
            SqlCommand getMaxIdCommand = new("SELECT MAX(ID) FROM dbo.UsersLogs", connection);
            var maxIdObj = getMaxIdCommand.ExecuteScalar();
            int maxId = maxIdObj == DBNull.Value ? 0 : Convert.ToInt32(maxIdObj);
            int newId = maxId + 1;
            int logId = newId;
            // DEBUG MessageBox.Show(logId + info.User + info.LogDate + info.InvIdOperatedOn + info.TypeOfOperationUsed);
            // Insert the new inventory item with the generated ID
            SqlCommand insertCommand = new("INSERT INTO dbo.UsersLogs ([Id], [Username], [DateOfOperation], [InvIdOperated], [TypeOfOperation]) VALUES (@idlog, @username, @dateoflog, @invlogged, @typeofoperation)", connection);

            insertCommand.Parameters.AddWithValue("@idlog", logId);
            insertCommand.Parameters.AddWithValue("@username", info.User);
            insertCommand.Parameters.AddWithValue("@dateoflog", info.LogDate);
            insertCommand.Parameters.AddWithValue("@invlogged", info.InvIdOperatedOn);
            insertCommand.Parameters.AddWithValue("@typeofoperation", info.TypeOfOperationUsed);
            insertCommand.ExecuteNonQuery();

            connection.Close();
        }


    }
}