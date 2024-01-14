using Assets.Scripts.Persistence.DAO.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesCodeDataSource : SQLiteDataSource
{
    public CharacterDAO CharacterDAO { get; protected set; }
    public WeaponDAO WeaponDAO { get; protected set; }

    private static GamesCodeDataSource instance;
    public static GamesCodeDataSource Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GamesCodeDataSource>();
                if(instance == null)
                {
                    var gamesCodeDataSourceObject = new GameObject("GamesCodeDataSource");
                    instance = gamesCodeDataSourceObject.AddComponent<GamesCodeDataSource>();
                    DontDestroyOnLoad(gamesCodeDataSourceObject);
                }
            }
            return instance;

        }
    }

    protected new void Awake()
    {


        this.databaseName = "GamesCode.db";
        this.copyDatabase = true;

        try
        {
            Debug.Log("this.databaseName :" + this.databaseName);
            base.Awake();
            CharacterDAO = new CharacterDAO(Instance);
            WeaponDAO = new WeaponDAO(Instance);
        }
        catch(Exception ex)
        {
            Debug.LogError($"Database not create! {ex.Message}");
        }

        print("Awake GamesCode");
    }
}