using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake ()
    {
        instance = this;
    }

    int allWoundsHealed;
    public Wound[] wounds;


    public void CheckWounds()
    {
        for (int i = 0; i < wounds.Length; i++)
        {
            if (wounds[i].isHealed)
            {
                allWoundsHealed++;
            }
        }

        if (allWoundsHealed == (wounds.Length -1))
        {
            GameWin();
        }
    }

    public void GameWin()
    {
        //WIN
    }

    public void GameLose()
    {
        //LOSE
    }


}
