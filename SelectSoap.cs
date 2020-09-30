
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectSoap : MonoBehaviour
{

   public int hoverFlag = 0;
   public int selectFlag = 0;
   private Vector3 target;
   public float sideTilt;
   public float tiltY = -17.3f;
   public Vector3 startPos;
   public float vel;
   public float sideVel;
   public float tiltYRef;
   public float timerEnd = 2f;
   public Vector3 ogPos;

    // Start is called before the first frame update
    void Start()
    {
        ogPos = this.transform.position;
        target = ogPos;
    }
 
   void OnMouseEnter()
   {
       hoverFlag = 1;
   }
   void OnMouseExit()
   {
       hoverFlag = 0;
   }

    // Update is called once per frame
    void Update()
    { 
         sideTilt = Mathf.Clamp(sideTilt,-120f,0f);
      transform.position = Vector3.MoveTowards(transform.position,target,13f * Time.deltaTime);

         if(hoverFlag == 1 && Input.GetMouseButton(0) && selectFlag == 0 && timerEnd > 0f && Control.selected == 0 && Control.soapFlag == 0)
        {   startPos = Input.mousePosition;
            selectFlag = 1;
            Control.selected = 1;
             if(SceneManager.GetActiveScene().buildIndex != 3)
            target = new Vector3( -2f , 6.21f , -14.16f);
            else
            target = new Vector3( -1.7f , 7.8f , -16.1f);
        }

        if(selectFlag == 1 && timerEnd > 0f)
         {
          sideTilt = Mathf.SmoothDamp(sideTilt,(Input.mousePosition.y - startPos.y),ref sideVel, 9f * Time.deltaTime);
          tiltY = Mathf.SmoothDamp(tiltY,-17.3f,ref tiltYRef , 6.5f * Time.deltaTime);
          transform.rotation = Quaternion.Euler(new Vector3(0f,tiltY,sideTilt));
         }
      
        if(!Input.GetMouseButton(0) || timerEnd <= 0f)
        {  if(selectFlag == 1)
           {
                selectFlag = 0;
                Control.selected = 0;
           } 
         target = ogPos;
         sideTilt = Mathf.SmoothDamp(sideTilt,0f,ref vel, 6.5f * Time.deltaTime);
         tiltY = Mathf.SmoothDamp(tiltY,-17.3f,ref tiltYRef ,6.5f * Time.deltaTime);
         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,tiltY,sideTilt));
         // this.transform.GetChild(0).gameObject.SetActive(false);
         //   this.transform.GetChild(1).gameObject.SetActive(false);
        }
      
       if(transform.rotation.eulerAngles.z < 325f && transform.rotation.eulerAngles.z > 280f && timerEnd > 0f)
       { 
          // this.transform.GetChild(0).gameObject.SetActive(true);
          this.transform.GetChild(0).gameObject.GetComponent<NVIDIA.Flex.FlexSourceActor>().isActive = true;
          timerEnd -= Time.deltaTime;
          if(timerEnd <= 0f)
          {    if(Control.soapFlag == 0 && Control.h202Flag == 0)
            {   
                Control.soapFlag++;
                if(this.gameObject.tag == "red")
                Control.redFlag = 1;
                else if(this.gameObject.tag == "green")
                Control.greenFlag = 1;
                else if(this.gameObject.tag == "yellow")
                Control.yellowFlag = 1;
                else if(this.gameObject.tag == "blue")
                Control.blueFlag = 1;
            }  
            else if(Control.soapFlag == 0 && Control.h202Flag == 1)
            {    
                 Control.readyFlag = 1;
                  Control.soapFlag++;
                   if(this.gameObject.tag == "red")
                Control.redFlag = 1;
                else if(this.gameObject.tag == "green")
                Control.greenFlag = 1;
                else if(this.gameObject.tag == "yellow")
                Control.yellowFlag = 1;
                else if(this.gameObject.tag == "blue")
                Control.blueFlag = 1;
            }
              this.transform.GetChild(0).gameObject.GetComponent<NVIDIA.Flex.FlexSourceActor>().isActive = false;
          }
       }
       else
       {
         this.transform.GetChild(0).gameObject.GetComponent<NVIDIA.Flex.FlexSourceActor>().isActive = false;
       }
    }
}
