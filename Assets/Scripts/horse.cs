using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class horse : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(cons_move.flip){ // 偵測皇帝的面朝方向使馬匹位置跟著微調
            transform.position = new Vector3(Constatine_skill.pos.position.x-0.25f+0.38f,-3.21f,0); 
        }
        else{
        transform.position = new Vector3(Constatine_skill.pos.position.x-0.25f,-3.21f,0);
    }
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = cons_move.flip; //照皇帝面朝的方向狂奔
        if(cons_move.flip){
            transform.Translate(-10f*Time.deltaTime,0,0);
        }
        else{
            transform.Translate(10f*Time.deltaTime,0,0);
            }

        if(Constatine_skill.wallTimer>0f&&transform.position.x<0.6f){
            Color c = spriteRenderer.color;
            c.a = 0.5f; //馬匹進入牆壁時透明度降低表示進入牆內
            spriteRenderer.color = c;
        }
        else{
            Color c = spriteRenderer.color;
            c.a = 1f;
            spriteRenderer.color = c;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Ground")&&!collision.gameObject.CompareTag("Cons")){
            Constatine_skill.ride = false;
            transform.position = new Vector3(-23,-32f,0); // 讓馬匹在撞到東西後離開鏡頭內
        }
    }
}
