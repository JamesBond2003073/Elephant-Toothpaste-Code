using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBeaker : MonoBehaviour
{

   public int hoverFlag = 0;
   public int selectFlag = 0;
   private Vector3 target;
   public float sideTilt;
   public float tiltY = 205f;
   public Vector3 startPos;
   public float vel;
   public float sideVel;
   public float tiltYRef;
   public int endFlag = 0;
   public float timerEnd = 3f;
   public Vector3 ogPos;

    // Start is called before the first frame update
    void Start()
    {
        ogPos = transform.position;
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

        if(selectFlag == 1)
         {
          sideTilt = Mathf.SmoothDamp(sideTilt,(Input.mousePosition.y - startPos.y),ref sideVel, 9f * Time.deltaTime);
          tiltY = Mathf.SmoothDamp(tiltY,192.13f,ref tiltYRef , 6.5f * Time.deltaTime);
          transform.rotation = Quaternion.Euler(new Vector3(0f,tiltY,sideTilt));
         }
      
    //  transform.rotation.eulerAngles = new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,Mathf.Clamp(transform.rotation.eulerAngles.z,-100f,0f));
        if(hoverFlag == 1 && Input.GetMouseButton(0) && selectFlag == 0 && timerEnd > 0f)
        {   startPos = Input.mousePosition;
            selectFlag = 1;
            if(SceneManager.GetActiveScene().buildIndex != 3)
            target = new Vector3( -0.35f , 7.5f , -14.3f);
            else
            target = new Vector3(-0.3f,9.2f,-16f);
        }

        if(!Input.GetMouseButton(0) || timerEnd <= 0f)
        {  if(selectFlag == 1)
         {
            selectFlag = 0;
           // endFlag = 1;
         }
         target = ogPos;
         sideTilt = Mathf.SmoothDamp(sideTilt,0f,ref vel,6.5f * Time.deltaTime);
         tiltY = Mathf.SmoothDamp(tiltY,205f,ref tiltYRef , 6.5f * Time.deltaTime);
         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,tiltY,sideTilt));
        
        }

        if(selectFlag == 1 && transform. position == target && timerEnd > 0f)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(true);
            
           
        }
       // Debug.Log(transform.rotation.eulerAngles.z);
      if(transform.rotation.eulerAngles.z < 240f && transform.rotation.eulerAngles.z > 220f && timerEnd > 0f)
       { 
          // this.transform.GetChild(0).gameObject.SetActive(true);
         // this.transform.GetChild(0).gameObject.GetComponent<NVIDIA.Flex.FlexSourceActor>().isActive = true;
          timerEnd -= Time.deltaTime;
          if(timerEnd <= 0f)
          {  if(Control.h202Flag == 0 && Control.soapFlag == 0)
            { 
                Control.h202Flag++;
            }  
            else if(Control.h202Flag == 0 && Control.soapFlag == 1)
            {
                 Control.readyFlag = 1;
                  Control.h202Flag++;
            }
            //  this.transform.GetChild(0).gameObject.GetComponent<NVIDIA.Flex.FlexSourceActor>().isActive = false;
          }
       }
       else
       {
        // this.transform.GetChild(0).gameObject.GetComponent<NVIDIA.Flex.FlexSourceActor>().isActive = false;
       }

    }
}
