using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //шаблон для создания яблок
    public GameObject applePrebaf;

    //Скорость движения яблони
    public float speed = 1f;

    //Расстояние. на котором должно изменяться направление движения яблони 
    public float leftAndRightEdge = 10f;

    //Вероятность случайного изменения направления движения
    public float chanceToChangeDirections = 0.1f;

    //Частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f; 
    
    void Start()
    {
        //сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);                                  //a
    }
    void DropApple()                                                    //b
    {
        GameObject apple = Instantiate<GameObject>(applePrebaf);        //c
        apple.transform.position = transform.position;                  //d
        Invoke("DropApple", secondsBetweenAppleDrops);                  //e
    }

    void Update()
    {
        // Простое перемещение
        Vector3 pos = transform.position;           //b
        pos.x += speed * Time.deltaTime;            //c
        transform.position = pos;                   //d
        // изменение направления
        if ( pos.x < -leftAndRightEdge)        //a
        {
            speed = Mathf.Abs(speed);          //b  //начать движение вправо
        }
        else if (pos.x > leftAndRightEdge)     //c
        {
            speed = -Mathf.Abs(speed);         //c   //начать движение влево
        }
    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)     
        {
            speed *= -1;  //Change Direction                   //b
        }
    }
   
}
        
    

