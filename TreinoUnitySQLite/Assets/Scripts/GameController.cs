using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Awake()
    {
        // Apenas chamando Instance para garantir que seja inicializado
        var dataSourceInstance = GamesCodeDataSource.Instance;
    }

    void Start()
    {
        // Agora é seguro acessar WeaponDAO, pois GamesCodeDataSource deve ter sido inicializado
        var w = GamesCodeDataSource.Instance.WeaponDAO.GetWeapon(1);
        if (w != null)
        {
            print(w.Name);
        }
        else
        {
            Debug.LogError("Weapon not found or WeaponDAO is null.");
        }
    }
}
