using UnityEngine;
using System;
using System.Threading.Tasks;
using JetBrains.Rider.Unity.Editor;
public class cons_move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isGrounded = false;
    private Rigidbody2D rb;
    private float movespeed = 3f;
    private float jumpforce = 5f;
    private bool a = false;
    public static bool flip;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().SetBool("moveing",false);
    }

    // Update is called once per frame
    void Update()
    {
        float movex = 0;
        a = false;
        flip = GetComponent<SpriteRenderer>().flipX;
        // 沒在進行祈禱或騎馬才能移動
        if(!GetComponent<Animator>().GetBool("ConsPray")&&!Constatine_skill.ride){ // 用動畫的bool偵測技能施放狀態
        if(Input.GetKey(KeyCode.A)){
            movex = -movespeed; // u
            GetComponent<SpriteRenderer>().flipX = true; // 讓角色面朝正確的方向
            flip = true;
            GetComponent<Animator>().SetBool("moveing",true);// 移動動畫
            a = true;
        }
        if(Input.GetKey(KeyCode.D)){
            movex = movespeed;
            GetComponent<SpriteRenderer>().flipX = false; // 讓角色面朝正確方向
            GetComponent<Animator>().SetBool("moveing",true); // 移動動畫
            a = true;
        }
        rb.linearVelocity = new Vector2(movex,rb.linearVelocity.y);
        if(Input.GetKey(KeyCode.W) && isGrounded){ // 踩在地上的時候才能跳躍
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            isGrounded = false;
        }
        if(!a){
            GetComponent<Animator>().SetBool("moveing",false);
        }
    }
    if(Constatine_skill.ride){ 
        rb.linearVelocity = new Vector2(0,0); // 騎馬時角色不能亂跑
        if(GetComponent<SpriteRenderer>().flipX){
            transform.Translate(-10f*Time.deltaTime,0,0);
        }
        else{
            transform.Translate(10f*Time.deltaTime,0,0);
        }
        
    }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
    }
    }
}
