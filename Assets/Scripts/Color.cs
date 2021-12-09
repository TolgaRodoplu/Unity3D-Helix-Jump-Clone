using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    public Material Ball_Mat;
    public Material Death_Mat;
    public Material Safe_Mat;
    public Material Cylinder_Mat;
    //public Color Background_Color;
    string[,] Color_Codes;
   
    private void Start()
    {
        Color_Codes = new string[,]
        {   // Ball       Death     Safe   Background  Cylinder
            { "FF0000", "FF8300", "474746", "FFD394" , "FFFFFF"},
            { "AE00FF", "ECFF00", "7CFF00", "BBFFB3",  "A8FFE3"},
            { "130E82", "FF00FF", "009BFF", "A2ADFF",  "A6FBFF"}
        };
        
        setColor();
    }

    void setColor()
    {
        int rand = Mathf.RoundToInt(Random.Range(0f, 2.49f));
        Ball_Mat.color = ReturnColor(Color_Codes[rand, 0]);
        Death_Mat.color = ReturnColor(Color_Codes[rand, 1]);
        Safe_Mat.color = ReturnColor(Color_Codes[rand, 2]);
        //Background_Color = ReturnColor(Color_Codes[rand, 0]);
        Cylinder_Mat.color = ReturnColor(Color_Codes[rand, 4]);
    }
    
    int HexToDec(string hex)
    {
        return System.Convert.ToInt32(hex, 16);
    }
    
    float HexToFloat(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    UnityEngine.Color ReturnColor(string hex)
    {
        float red = HexToFloat(hex.Substring(0, 2));
        float blue = HexToFloat(hex.Substring(2, 2));
        float green = HexToFloat(hex.Substring(4, 2));
        return new UnityEngine.Color(red, blue, green);
    }
}
