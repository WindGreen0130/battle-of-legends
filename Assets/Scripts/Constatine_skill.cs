using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Collections;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;


public class Constatine_skill : MonoBehaviour
{
    float atk = 15;
    int pray_succ_count = 0;
    public static bool ride = false;
    public static Transform pos;
    public static float wallTimer = -1;
    public Transform theWall;
    int g = 6;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
    }

    // Update is called once per frame
    async void Update()
    {
        if(Input.GetKey(KeyCode.J)&&ride ==false){
            GetComponent<Animator>().SetBool("ConsPray",true); // 祈禱動畫
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(1000);  // 延遲 1 秒（1000 毫秒）
            int rnd = UnityEngine.Random.Range(1,g);
            if(rnd == 1|| rnd == 10 || rnd == 9 || rnd == 8){
                GetComponent<Animator>().SetBool("ConsPray_Succ",true); //祈禱成功
                pray_succ_count++;
            }
            else{
                GetComponent<Animator>().SetBool("ConsPray_Succ",false); // 祈禱失敗
            }
            
        }
        atk = atk+pray_succ_count*atk*0.3f; // 依照祈禱成功次數增加atk
        GetComponent<Animator>().SetBool("ConsPray",false); // 祈禱結束動畫關閉
        }
        if(Input.GetKey(KeyCode.K)&&ride ==false){
            pos = transform;
            transform.position = new Vector3(transform.position.x,-0.9f,transform.position.z); // 讓角色y軸位置與馬匹相同
            GameObject horse = GameObject.Find("horse");
        if(GetComponent<SpriteRenderer>().flipX){ // 角色面朝方向會讓馬匹位置需要微調
            horse.transform.position = new Vector3(pos.position.x-0.25f+0.38f,-3.21f,0); 
        }
        else{
            horse.transform.position = new Vector3(pos.position.x-0.25f,-3.21f,0);
        }
        ride = true;
        }

        if(Input.GetKey(KeyCode.L)){
            wallTimer = 10f; // 牆壁出現的倒計時
            theWall.position = new Vector3(-1.3f,2.8f,0);
            
        }
        wallTimer -= Time.deltaTime;
        if(wallTimer<0f){
            theWall.position = new Vector3(100f,100f,0); 
            g = 6; // 牆壁消失後祈禱成功率回歸正常
        }
        else{
            g = 11; // 牆壁存在時祈禱成功率增加
        }
        if(wallTimer>0f&&transform.position.x<0.6f){
            Color c = spriteRenderer.color;
            c.a = 0.5f; //角色進入牆壁時透明度降低表示進入牆內
            spriteRenderer.color = c;
        }
        else{
            Color c = spriteRenderer.color;
            c.a = 1f;
            spriteRenderer.color = c;
        }
    }
    }
