using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public Text scoreText;
    public GameObject gameoverPanel;

    private int val;
    private int[] loc= new int[16];
    private int count=0;
    private int randomScore;
    private int sceneNum;
    private int[,] Array4 = new int[4,4];
    private int[,] valMap4 = new int[4,4];
    private int[,] Zeros4 = new int[4,4];
    private int[,] Array3 = new int[3,3];
    private int[,] valMap3 = new int[3,3];
    private int[,] Zeros3 = new int[3,3];
    void Awake() {
        if(instance==null)
        {
            instance=this;
        }   
    }
    public int getVal()
    {
        return val;
    }
    public void SetNum4()
    {
        randomScore=Random.Range(0,16);
        while(contain4(randomScore)==0)
        {
            randomScore=Random.Range(0,16);
        }
         val=CoverSpawn4.instance.pos[randomScore];
        scoreText.text = val.ToString();
         loc[count]=randomScore;
         count++;
         sceneNum=4;
         SetArray4();
    }
    void SetArray4()
    {
        if (Array4[0,0]!=0)
        return;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Array4[i,j]=CoverSpawn4.instance.pos[(i*4)+j];
            }
            
        }
    }

    public void SetNum3()
    {
        randomScore=Random.Range(0,9);
        while(contain3(randomScore)==0)
        {
            randomScore=Random.Range(0,9);
        }
         val=CoverSpawn3.instance.pos3[randomScore];
        scoreText.text = val.ToString();
         loc[count]=randomScore;
         count++;
         sceneNum=3;
         SetArray3();
    }
    void SetArray3()
    {
        if (Array3[0,0]!=0)
        return;
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Array3[i,j]=CoverSpawn3.instance.pos3[(i*3)+j];
            }
            
        }
    }
     
    int contain4(int a)
    {
        
        if (count==0!||count>13)
            return 1 ;
        else
        {
            for(int i=0;i<count;i++)
            {
                if(a==loc[i])
                {
                    return 0;
                }
            }

        }    
        
        
        return 1;
    }
    int contain3(int a)
    {
        
        if (count==0!||count>7)
            return 1 ;
        else
        {
            for(int i=0;i<count;i++)
            {
                if(a==loc[i])
                {
                    return 0;
                }
            }

        }    
        
        
        return 1;
    }
    int outofbounds4(int i,int j)
    {
        if(i<0||j<0)
        {
            return 0;
        }
        else
        {
            return valMap4[i,j];
        }
    }
    void Soln()
    {
        int x=0,y=0;
        if(sceneNum==4)
        {
            
            for (int i = 0; i < 4; i++)
            {
                x=0;y=0;
                for (int j = 0; j < 4; j++)
                {
                    x+=valMap4[i,j];
                    y+=valMap4[j,i];
                }
                if(x==4||y==4)
                {
                    print("bingo!!");
                    Gameover();
                    break;
                }
            }
            
        }
        else if(sceneNum==3)
        {
            
            for (int i = 0; i < 3; i++)
            {
                x=0;y=0;
                for (int j = 0; j < 3; j++)
                {
                    x+=valMap3[i,j];
                    y+=valMap3[j,i];
                }
                if(x==3||y==3)
                {
                    print("bingo!!");
                    Gameover();
                    break;
                }
            }
            
        }
    }
    void Start()
    {
       
    }

    public void Matrix(int matVal)
    {
        if(sceneNum==4)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(Array4[i,j]==matVal)
                    {
                        valMap4[i,j]=1;
                        break;
                    }
                }
            
            }
            Soln();

            SetNum4();
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(Array3[i,j]==matVal)
                    {
                        valMap3[i,j]=1;
                        break;
                    }
                }
            
            }
            Soln();
            SetNum3();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    void Gameover() 
    {
         
         
         gameoverPanel.SetActive(true);
         
    }
}

