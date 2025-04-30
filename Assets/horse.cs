using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class horse : MonoBehaviour
{
    static bool exist = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(cons_move.flip){
            transform.position = new Vector3(Constatine_skill.pos.position.x-0.25f+0.38f,-3.21f,0);
        }
        else{
        transform.position = new Vector3(Constatine_skill.pos.position.x-0.25f,-3.21f,0);
    }
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = cons_move.flip;
        if(cons_move.flip){
            transform.Translate(-10f*Time.deltaTime,0,0);
        }
        else{
            transform.Translate(10f*Time.deltaTime,0,0);
            }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Ground")&&!collision.gameObject.CompareTag("Cons")){
            Constatine_skill.ride = false;
            transform.position = new Vector3(-23,-32f,0);
        }
    }
}
