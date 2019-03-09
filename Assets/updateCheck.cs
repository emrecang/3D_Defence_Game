using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateCheck : MonoBehaviour
{
    public int a=5, b=5, c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a = changeA(a);
        b = changeB(b);

        c = a * b;
        Debug.Log("Değer = " + c);
    }

    public int changeA(int a)
    {
        a = 3;
        
        for(int i =0; i<10000; i++)
        {
            for (int j = 0; j < 10000; j++)
            {
                for (int k = 0; k < 10000; k++)
                {

                }
            }
        }

        Debug.Log("a");
        return a;
    }
    public int changeB(int b)
    {
        b = 4;
        Debug.Log("b");
        return b;
        
    }
}
