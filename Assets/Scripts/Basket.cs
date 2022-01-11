using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    //Эта строка подключает библиотеку для работы с ГИП //a

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;                                            //a

    void Start()
    {
        //Подключить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");        //b
        //Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>();
        //Установить начальное число очков равным 0
        scoreGT.text = "0";
    }

    
    void Update()
    {
        //Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;           //a

        //Координата Z камеры определяет, как далеко в трехмерном пространстве находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;   //b

        //Преобразовать точку на двухмерной плоскости экрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);  //c

        //Переместить корзину вдоль оси X в координату X указателем мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
    void OnCollisionEnter(Collision coll)             //a
    {
        //Отыскать яблоко, попавшее в корзину
        GameObject collidedWith = coll.gameObject;    //b
        if( collidedWith.tag == "Apple")              //c
        {
            Destroy(collidedWith);

            //Преобразовать текст в scoreGT в челое число
            int score = int.Parse(scoreGT.text);       //d
            //Добавить очки за пойманное яблоко 
            score += 100;
            //Преобразовать число очков обратно в сторону и вывести ее на экран 
            scoreGT.text = score.ToString();

            //Запомнить высшее достижение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
