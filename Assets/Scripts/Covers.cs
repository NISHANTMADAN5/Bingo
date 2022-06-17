using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covers : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int num ;
    void Start()
    {
        
    }
    private void OnMouseDown() {
        print(GameManager.instance.getVal());
        if(GameManager.instance.getVal()==num)
        {
           
            Destroy(gameObject);
            GameManager.instance.Matrix(num);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclick()
    {
        
    }
}
