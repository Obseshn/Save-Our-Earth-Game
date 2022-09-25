using System;
using UnityEngine;
   
public static class SizeChanger
{
    public static Vector3 GetRandomChangeSize(float minSize, float maxSize)     
    {           
        float changeIndex = UnityEngine.Random.Range(minSize, maxSize);
                

        Vector3 newSize = new Vector3(changeIndex / 3, changeIndex / 3, changeIndex / 3); // 3 - just koefficient value        
        return newSize;
    }
}
