using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 將自己定位在畫面外隨機位置
        transform.position = new Vector3(Random.Range(-18.1f,-11.9f),Random.Range(0.9f,4.1f),0);
    }

    // Update is called once per frame
    void Update()
    {
        // 以隨機速度向右移動
        transform.Translate(Random.Range(1.9f,5.1f)*Time.deltaTime,0,0);
        if(transform.position.x>17){
            // 出畫面後刪除物件
            Destroy(gameObject);
            // 呼叫父物件複製自己
            transform.parent.GetComponent<clone>().SpawnCrow();
        }
    }
}
