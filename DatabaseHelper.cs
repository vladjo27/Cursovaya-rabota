using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ScooterAdmin;

/// <summary>
/// Помощник для работы с Access.
/// В формах остаётся понятная логика, а техническая работа с OleDb находится здесь.
/// </summary>
public static class DatabaseHelper
{
    private static readonly string AuthConnectionString =
        $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppContext.BaseDirectory, "AuthDB.accdb")};";

    private static readonly string MainConnectionString =
        $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(AppContext.BaseDirectory, "ScooterDB.accdb")};";

    public static OleDbConnection GetAuthConnection() => new(AuthConnectionString);
    public static OleDbConnection GetMainConnection() => new(MainConnectionString);

    /// <summary>
    /// Выполняет обычный SELECT-запрос, написанный прямо в C#.
    /// </summary>
    public static DataTable ExecuteQuery(OleDbConnection connection, string sql, params OleDbParameter[] parameters)
    {
        DataTable table = new();

        using OleDbCommand command = new(sql, connection);
        command.Parameters.AddRange(parameters);

        using OleDbDataAdapter adapter = new(command);
        adapter.Fill(table);

        return table;
    }

    /// <summary>
    /// Выполняет обычный INSERT / UPDATE / DELETE, написанный прямо в C#.
    /// </summary>
    public static int ExecuteNonQuery(OleDbConnection connection, string sql, params OleDbParameter[] parameters)
    {
        bool wasOpen = connection.State == ConnectionState.Open;
        if (!wasOpen)
            connection.Open();

        using OleDbCommand command = new(sql, connection);
        command.Parameters.AddRange(parameters);
        int affectedRows = command.ExecuteNonQuery();

        if (!wasOpen)
            connection.Close();

        return affectedRows;
    }

    /// <summary>
    /// Выполняет обычный запрос, который возвращает одно значение: COUNT, SUM и т.п.
    /// </summary>
    public static object? ExecuteScalar(OleDbConnection connection, string sql, params OleDbParameter[] parameters)
    {
        bool wasOpen = connection.State == ConnectionState.Open;
        if (!wasOpen)
            connection.Open();

        using OleDbCommand command = new(sql, connection);
        command.Parameters.AddRange(parameters);
        object? value = command.ExecuteScalar();

        if (!wasOpen)
            connection.Close();

        return value;
    }

    /// <summary>
    /// Выполняет сохранённый запрос Access по имени и возвращает таблицу.
    /// Например: qryAdminAllScooters.
    /// </summary>
    public static DataTable ExecuteQueryByName(OleDbConnection connection, string queryName, params OleDbParameter[] parameters)
    {
        DataTable table = new();

        using OleDbCommand command = new(queryName, connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddRange(parameters);

        using OleDbDataAdapter adapter = new(command);
        adapter.Fill(table);

        return table;
    }
}
