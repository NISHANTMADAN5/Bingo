using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSpawn4 : MonoBehaviour
{
    // Start is called before the first frame update
 public GameObject[] Covers;
    public static CoverSpawn4 instance;
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
        Spawn4();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    float x=-2.44f;
    float y= 2.25f;
    public int[] pos= new int[16];
    private int rand;
    int count=0;
    int contain(int a)
    {
        
        if (count==0)
            return 1 ;
        else
        {
            for(int i=0;i<count;i++)
            {
                if(a+1==pos[i])
                {
                    return 0;
                }
            }

        }    
        
        
        return 1;
    }
    
    void Spawn4()
    {
         
        for(int i=0;i<4;i++)
        {
            x=-2.44f;
            for (int j = 0;j<4;j++)
            {
                rand = Random.Range(0,Covers.Length);
                 while(contain(rand)==0)
                 {
                     rand=Random.Range(0,Covers.Length);
                 }
                
                Vector3 randomPos= new Vector3(x,y,transform.position.z);
                Instantiate(Covers[rand],randomPos,transform.rotation);
                x+= 1.66f;
                pos[count]=rand+1;
               // print(pos[count]+" "+rand);
                count++;
                
            }
            y-=1.66f;
        }
        GameManager.instance.SetNum4();
    }
}
