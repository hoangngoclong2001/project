using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }
    public int level;
    public float health;
    public int score;
    public void SavePlayer()
    {
        DataManager.instance.SavePlayer();
        DataManager.instance.isSaveGame = true;
    }
public void LoadPlayer()
    {
        DataManager.instance.LoadPlayer();
        DataManager.instance.isLoadGame = true;

        this.level = DataManager.instance.data.level;
        this.health = DataManager.instance.data.health;
        this.score = DataManager.instance.data.score;
        
        Vector3 position;

        position.x = DataManager.instance.data.position[0];
        position.y = DataManager.instance.data.position[1];
        position.z = 0;
        transform.position = position;

    }
}
