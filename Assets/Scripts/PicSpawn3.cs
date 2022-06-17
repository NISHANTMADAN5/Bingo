using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicSpawn3 : MonoBehaviour
{
    // Start is called before the first frame update
    
     public GameObject[] Pics;
    public static PicSpawn3 instance;
    void Awake() {
        if(instance==null)
        {
            instance=this;
        }    
    }
    [SerializeField]
    float maxx=7.5f;
    
    void Start()
    {
        Spawn3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float x=-2f;
    float y= 2.25f;
    void Spawn3()
    {
         
        for(int i=0;i<3;i++)
        {
            x=-2f;
            for (int j = 0;j<3;j++)
            {
                int rand = Random.Range(0,Pics.Length);
                Vector3 randomPos= new Vector3(x,y,transform.position.z);
                Instantiate(Pics[rand],randomPos,transform.rotation);
                x+= 2f;
                print(this.name);
            }
            y-=2.25f;
        }
        
    }
    
}

