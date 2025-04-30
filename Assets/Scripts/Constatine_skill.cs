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
    float wallTimer = -1;
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
            GetComponent<Animator>().SetBool("ConsPray",true);
        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(1000);  // 延遲 1 秒（1000 毫秒）
            int rnd = UnityEngine.Random.Range(1,g);
            if(rnd == 1|| rnd == 10 || rnd == 9 || rnd == 8){
                GetComponent<Animator>().SetBool("ConsPray_Succ",true); //祈禱成功
                pray_succ_count++;
            }
            else{
                GetComponent<Animator>().SetBool("ConsPray_Succ",false);
            }
            
        }
        atk = atk+pray_succ_count*atk*0.3f;
        GetComponent<Animator>().SetBool("ConsPray",false);
        }
        if(Input.GetKey(KeyCode.K)&&ride ==false){
            pos = transform;
            transform.position = new Vector3(transform.position.x,-0.483f,transform.position.z);
            GameObject horse = GameObject.Find("horse");
        if(GetComponent<SpriteRenderer>().flipX){
            horse.transform.position = new Vector3(pos.position.x-0.25f+0.38f,-3.21f,0);
        }
        else{
            horse.transform.position = new Vector3(pos.position.x-0.25f,-3.21f,0);
        }
        ride = true;
        }

        if(Input.GetKey(KeyCode.L)){
            // TriggerZoomEffect();
            wallTimer = 10f;
            theWall.position = new Vector3(-1.3f,2.8f,0);
            
        }
        wallTimer -= Time.deltaTime;
        if(wallTimer<0f){
            theWall.position = new Vector3(100f,100f,0);
            g = 6;
        }
        else{
            g = 11;
        }
        if(wallTimer>0f&&transform.position.x<0.6f){
            Color c = spriteRenderer.color;
            c.a = 0.5f;
            spriteRenderer.color = c;
        }
        else{
            Color c = spriteRenderer.color;
            c.a = 1f;
            spriteRenderer.color = c;
        }
    }
    }
