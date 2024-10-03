using Spectre.Console;
using Dapper;
using System.Data.SQLite;

namespace CodingTracker;

public class TableVisualizer
{
    public static void MakeTable()
    {
        using (var connection = new SQLiteConnection("Data Source=tracker.db")) {
            var reader = connection.ExecuteReader("SELECT * FROM tracker");

            while (reader.Read()) {
                var table = new Table();

                table.AddColumn("ID");
                table.AddColumn("Date");
                table.AddColumn("Start Time");
                table.AddColumn("End Time");
                table.AddColumn("Duration");

                while(reader.Read()) {
                    table.AddRow(reader["Id"].ToString() ?? "",
                                 reader["Date"].ToString() ?? "",
                                 reader["StartTime"].ToString() ?? "",
                                 reader["EndTime"].ToString() ?? "",
                                 reader["Duration"].ToString() ?? "");
                }
                AnsiConsole.Write(table);
            }
        }
    }
}
