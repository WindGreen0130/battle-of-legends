using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class clone : MonoBehaviour
{
    [SerializeField] GameObject crow;
    public void SpawnCrow()
    {
        // 複製一烏鴉至當前物件所在位置，但其為空物件，故所在位置為(0,0,0)
        Instantiate(crow,transform);
    }
}
