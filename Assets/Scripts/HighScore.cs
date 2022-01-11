using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;

    void Awake()                                        //a
    {
        //Если значение HighScore уже существует в PlayerPrefs, почитать его 
        if (PlayerPrefs.HasKey("HighScore"))            //b
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //Сохранить высшее достижение HighScore в хранилище
        PlayerPrefs.SetInt("HighScore", score);          //c
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        //Обновить HighScore в PlayerPrefs. если необходимо 
        if (score > PlayerPrefs.GetInt("HighScore"))        //d
        {
            PlayerPrefs.SetInt("HighScore", score);
        }  
    }
}
