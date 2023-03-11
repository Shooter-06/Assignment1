using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int score;

    public static GameManager Instance {
        get {
            if(instance==null) {
                instance = new GameManager();
            }
 
            return instance;
        }
    }
    
    void Awake()
    {
        instance = this;
    }
 
    void UpdateScore()
    {
        // TODO
    }
}
