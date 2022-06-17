using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSpawn3 : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject[] Covers;
    public static CoverSpawn3 instance;
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
    public int[] pos3= new int[9];
    private int rand;
    int contain(int a)
    {
        
        if (pos3.Length==0)
            return 1 ;
        else
        {
            for(int i=0;i<pos3.Length;i++)
            {
                if(a+1==pos3[i])
                {
                    return 0;
                }
            }

        }    
        
        
        return 1;
    }
    int count=0;
    void Spawn3()
    {
         
        for(int i=0;i<3;i++)
        {
            x=-2f;
            for (int j = 0;j<3;j++)
            {
                rand = Random.Range(0,Covers.Length);
                 while(contain(rand)==0)
                 {
                     rand=Random.Range(0,Covers.Length);
                 }
                Vector3 randomPos= new Vector3(x,y,transform.position.z);
                Instantiate(Covers[rand],randomPos,transform.rotation);
                x+= 2f;
                pos3[count]=rand+1;
                count++;
                
            }
            y-=2.25f;
        }
        GameManager.instance.SetNum3();
    }
}
