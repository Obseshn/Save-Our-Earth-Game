using System;
using UnityEngine;
   
public static class SizeChanger
{
    public static Vector3 GetRandomChangeSize(float minSize, float maxSize)     
    {           
        float changeIndex = UnityEngine.Random.Range(minSize, maxSize);
           
        if (changeIndex < 1)          
        {               
            Debug.LogError("Size of object less than 1, it should be destroyed!");        
        }        

        Vector3 newSize = new Vector3(changeIndex / 3, changeIndex / 3, changeIndex / 3); // 3 - just koefficient value        
        return newSize;
    }
}
