using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;                       //a
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);                           //b
            //Получить ссылку на компонент ApplePicker главной камеры Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();   //b
            //Вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed();                                        //c
        }
    }
}
