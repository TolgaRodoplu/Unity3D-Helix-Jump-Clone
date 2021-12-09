using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Maneger : MonoBehaviour
{
    static int Stage = 1;
    static int Score = 0;
    static int Best = 0;
    int Count;
    int Count_To = 4;
    public Transform Canvas;
    public Text Score_Text;
    public GameObject Cylinder;
    public Slider Progression;
    bool isStarted = false;


    void Start()
    {
        Count = 1;
        Score_Text.text = Score.ToString();
        Canvas.Find("Best").GetComponent<Text>().text = Best.ToString();
        Canvas.Find("Stage").GetComponent<Text>().text = Stage.ToString();
        Canvas.Find("Next_Stage").GetComponent<Text>().text = (Stage + 1).ToString();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(!isStarted)
        {
            Canvas.Find("Best").GetComponent<Text>().enabled = false;
            Canvas.Find("Best_Label").GetComponent<Text>().enabled = false;
            isStarted = false;
        }
        if (other.tag.Equals("Pass"))
        {
            Score_Up();
            Count++;
            Destroy_Ring(other.transform.parent.parent.gameObject);
            //Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Disk"))
        {
            if(Count >= Count_To)
            {
                Score_Up();
                Count = 1;
                Destroy_Ring(collision.transform.parent.parent.gameObject);
                //Destroy(collision.gameObject.transform.parent.gameObject);
            }
               
            else
                 Count = 1;
        }
        
        if(collision.gameObject.tag.Equals("Success"))
        {
            Pause(true);
        }
        
        if (collision.gameObject.tag.Equals("Death"))
        {
            if (Count >= Count_To)
            {
                Score_Up();
                Count = 1;
                gameObject.GetComponent<Ball>().Jump();
                Destroy_Ring(collision.transform.parent.parent.gameObject);
                //Destroy(collision.gameObject.transform.parent.gameObject);
            }
            
            else
                Pause(false);
            
        }
    }

    void Score_Up()
    {
        FindObjectOfType<AudioManeger>().PlaySound("Pass");
        Progression.value += 3f;
        Score += Stage * Count;
        Score_Text.text = Score.ToString();
    }

    
    
    void Pause(bool Dead_Success)
    {
        Time.timeScale = 0;
        Canvas.Find("Button").gameObject.SetActive(true);
        Cylinder.GetComponent<Control>().enabled = false;
        Canvas.Find("Pause_Image").gameObject.SetActive(true);
        Canvas.Find("Percent_Text").GetComponent<Text>().text = Progression.value.ToString() + "% COMPLETED";

        if (Dead_Success)
        {
            Canvas.Find("Button").GetComponentInChildren<Text>().text = "TAP TO CONTINUE";
            Stage++;
            if (Score > Best)
            {
                Best = Score;
            }
                
        }
        else
        {
            FindObjectOfType<AudioManeger>().PlaySound("Death");
            
            Canvas.Find("Button").GetComponentInChildren<Text>().text = "TAP TO RESTART";
            Score = 0;
        }
    }

    void Destroy_Ring(GameObject Object)
    {
        Destroy(Object);
    }
    
}
