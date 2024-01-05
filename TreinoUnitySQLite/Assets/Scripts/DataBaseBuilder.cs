using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DataBaseBuilder : MonoBehaviour
{
    protected SqliteConnection Connection => new SqliteConnection($"Data Source = {this.databasePath};");
    public string DatabaseName;
    protected string databasePath;
    

    private void Awake()
    {
        if(string.IsNullOrEmpty(this.DatabaseName))
        {
            Debug.LogError("Database name is empty");
            return;
        }
        CreateDatabaseFileIfNotExists();
    }

    private void CreateDatabaseFileIfNotExists()
    {
        this.databasePath = Path.Combine(Application.persistentDataPath, this.DatabaseName);

        if(!File.Exists(this.databasePath))
        {
            SqliteConnection.CreateFile(this.databasePath);
            Debug.Log($"Database path: {this.databasePath}");
        }
    }
}
