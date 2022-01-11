using System.Collections;
using System.Collections.Generic;                     //a
using UnityEngine;
using UnityEngine.SceneManagement;                    //b

public class ApplePicker : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();                       //c
        for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);                        //d
        }
    }
    public void AppleDestroyed()                                               //a
    {
        //Удалить все упавшие яблоки 
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); //b
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //Удалить одну корзину
        //Получить индекс последней корзины          //e
        int basketIndex = basketList.Count-1;
        //Получить ссылку на этот игровой объект Basket
        GameObject tBasketGO = basketList[basketIndex];
        //Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        //Если корзин не осталось, перезапустите игру
        if( basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");            //a
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
