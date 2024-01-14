using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public static class MySqliteCommandExt
{
    public static int ExecuteNonQueryWithFk(this SqliteCommand command)
    {
        var tmp = command.CommandText;

        command.CommandText = $"PRAGMA foreign_keys = true; {tmp}";
        return command.ExecuteNonQuery();

    }
}
