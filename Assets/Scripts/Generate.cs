using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    
    public Transform main;
    GameObject current;
    float Height;
    int Count;
    
    
    private void Start()
    {
        Height = 0;
        Count = 34;
        Generate_Cylinder();
    }

    void Generate_Cylinder()
    {
        for(int i = 0; i  <= Count; i++)
        {
            
            current = Instantiate(Generate_Platform(i) as GameObject);
            current.transform.SetParent(main);
            /*
            if(i == Count)
               current.transform.localScale = new Vector3(0.28f, 0.01f, 0.28f);

            else
            {
                current.transform.localScale = new Vector3(0.6f, 0.02f, 0.6f);
                */
                if(i == 0)
                    current.transform.rotation = Quaternion.Euler(0, Random.Range(-150f, 110f), 0);
                else
                    current.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            

            current.transform.position = new Vector3(0f, Height, 0f);
            Height = Height - 3f;
        }
    }

    
    Object Generate_Platform(int i)
    {
        if(i == 0)
            return Resources.Load("Start");

        else if(i == Count)
            return Resources.Load("Success");

        else//Return Random Prefab
            return Resources.Load(Random.Range(1, 36).ToString());

    }
}
