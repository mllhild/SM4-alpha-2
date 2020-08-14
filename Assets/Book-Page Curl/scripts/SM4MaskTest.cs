using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4MaskTest : MonoBehaviour
{
   public RectTransform parent;
   public RectTransform child01;
   public RectTransform child02;
   public RectTransform childChild;
   public RectTransform page;
   private float inc;
   public bool sinValue;
   public bool sinSquare;
   public float speed = 0.8f;

   private void Update()
   {
      inc = Time.realtimeSinceStartup * speed;
      GOChild(inc);
   }

   public void GOParent(float counter)
   {
      
   }
   public void GOChild(float counter)
   {
      float normalizedCounter = 1 - counter;
      float sencounter = (float)Math.Sin(normalizedCounter * Math.PI / 2f);
      
      if(sinValue)
         normalizedCounter = sencounter;
      if(sinSquare)
         normalizedCounter = sencounter*sencounter;
      
      
      //print($"{counter} {sencounter}");
      if(counter < 1)
      {
         child01.localScale = new Vector3(normalizedCounter, 1,1);
         child01.localPosition = new Vector3(child01.sizeDelta.x*normalizedCounter/2f,child01.localPosition.y,child01.localPosition.z);
      }
      else if(counter > 1 && counter < 2)
      {
         var norm = -normalizedCounter;
         if (sinSquare)
            norm = normalizedCounter;
         child02.localScale = new Vector3(norm, 1,1);
         child02.localPosition = new Vector3(-child02.sizeDelta.x/2*norm,child02.localPosition.y,child02.localPosition.z);
      }
      
      
      
   }
   public void GOChildChild(float counter)
   {
      
   }

   public void Test01(float scaler)
   {
      // moves top part up
      //page.offsetMax = new Vector2(page.offsetMax.x,page.offsetMax.y + inc);
      // moves bottom part up
      //page.offsetMin = new Vector2(page.offsetMin.x,page.offsetMin.y + inc);
      // moves entire GO up
      //page.position = new Vector2(page.position.x,page.position.y+inc);
      //page.localPosition = new Vector2(page.localPosition.x,page.localPosition.y+inc);
      // expands up and down equally while keeping the position
      //page.sizeDelta = new Vector2(page.sizeDelta.x, page.sizeDelta.y + inc);
      // moves top part up
      //page.anchorMax = new Vector2(page.anchorMax.x, page.anchorMax.y+inc/100);
      // moves bottom part up
      //page.anchorMin = new Vector2(page.anchorMin.x, page.anchorMin.y+inc/100); 
      // rotation that stops at -180 or +180
      //page.rotation = new Quaternion(page.rotation.x,page.rotation.y,200f,page.rotation.w);
      // rotation that works without stopping at 180. no idea why rotation exists
      //page.eulerAngles = new Vector3(page.eulerAngles.x,page.eulerAngles.y,page.eulerAngles.z+inc);
   }
}
