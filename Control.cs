using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
 
 public GameObject initialRed;
 public GameObject outRed;
 public GameObject initialGreen;
 public GameObject outGreen;
 public GameObject initialYellow;
 public GameObject outYellow;
 public GameObject initialBlue;
 public GameObject outBlue;
 public float timer = 1f;
 public float timerEnd = 4f;
 public float timerUp = 1f;
public int endFlag = 0;
public Material mat;
public float intensity = 1f;
public static int readyFlag = 0;
public static int soapFlag = 0;
public static int h202Flag = 0;
public static int selected = 0;
public static int redFlag = 0;
public static int blueFlag = 0;
public static int greenFlag = 0;
public static int yellowFlag = 0;
public GameObject flask;
public GameObject upButton;

    // Start is called before the first frame update
    void Start()
    {
     readyFlag = 0;
 soapFlag = 0;
  h202Flag = 0;
 selected = 0;
 redFlag = 0;
 blueFlag = 0;
 greenFlag = 0;
 yellowFlag = 0;
 endFlag = 0;
 intensity = 0.03f;
 if(SceneManager.GetActiveScene().buildIndex != 3)
 {
 timer = 1.2f;
 timerEnd = 6f;
 timerUp = 1f;
 }
 else
 {
      timer = 2.2f;
 timerEnd = 6f;
 timerUp = 1f;
 }
    }


    // Update is called once per frame
    void Update()
    {  if(timerEnd <= 0f && timerUp > 0f)
    {
     timerUp -= Time.deltaTime;
     if(timerUp <= 0f)
     {
         upButton.SetActive(true);
     }
    }

   if(redFlag == 1)
  {
   if(readyFlag == 1)
   {
       initialRed.SetActive(true);
       flask.GetComponent<MeshCollider>().enabled = false;

       

      // readyFlag = 0;
   }

        if(initialRed.activeSelf && outRed.activeSelf == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f && !outRed.activeSelf)
            {
                outRed.SetActive(true);
            }
        }
        if(outRed.activeSelf && endFlag == 0)
        {
            timerEnd -= Time.deltaTime;
            if(timerEnd <= 0f)
            {   endFlag = 1;
                var emissionOut = outRed.GetComponent<ParticleSystem>().emission;
              var emissionIn = initialRed.GetComponent<ParticleSystem>().emission;
              var rendererIn = initialRed.GetComponent<ParticleSystemRenderer>();

             float factor = Mathf.Pow(2,intensity);
             Debug.Log(factor);
            //  mat.SetColor("_Color", new Color(191f * factor,9f * factor,9f * factor, 1f));
            emissionIn.rateOverTime = 0f; 
            emissionOut.rateOverTime = 0f; 
          
            
            }
        }
    }

    if(blueFlag == 1)
  {
   if(readyFlag == 1)
   {
       initialBlue.SetActive(true);
       flask.GetComponent<MeshCollider>().enabled = false;

       

      // readyFlag = 0;
   }

        if(initialBlue.activeSelf && outBlue.activeSelf == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f && !outBlue.activeSelf)
            {
                outBlue.SetActive(true);
            }
        }
        if(outBlue.activeSelf && endFlag == 0)
        {
            timerEnd -= Time.deltaTime;
            if(timerEnd <= 0f)
            {   endFlag = 1;
                var emissionOut = outBlue.GetComponent<ParticleSystem>().emission;
              var emissionIn = initialBlue.GetComponent<ParticleSystem>().emission;
              var rendererIn = initialBlue.GetComponent<ParticleSystemRenderer>();

             float factor = Mathf.Pow(2,intensity);
             Debug.Log(factor);
            //  mat.SetColor("_Color", new Color(191f * factor,9f * factor,9f * factor, 1f));
            emissionIn.rateOverTime = 0f; 
            emissionOut.rateOverTime = 0f; 
          
            
            }
        }
    }

    if(yellowFlag == 1)
  {
   if(readyFlag == 1)
   {
       initialYellow.SetActive(true);
       flask.GetComponent<MeshCollider>().enabled = false;

       

      // readyFlag = 0;
   }

        if(initialYellow.activeSelf && outYellow.activeSelf == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f && !outYellow.activeSelf)
            {
                outYellow.SetActive(true);
            }
        }
        if(outYellow.activeSelf && endFlag == 0)
        {
            timerEnd -= Time.deltaTime;
            if(timerEnd <= 0f)
            {   endFlag = 1;
                var emissionOut = outYellow.GetComponent<ParticleSystem>().emission;
              var emissionIn = initialYellow.GetComponent<ParticleSystem>().emission;
              var rendererIn = initialYellow.GetComponent<ParticleSystemRenderer>();

             float factor = Mathf.Pow(2,intensity);
             Debug.Log(factor);
            //  mat.SetColor("_Color", new Color(191f * factor,9f * factor,9f * factor, 1f));
            emissionIn.rateOverTime = 0f; 
            emissionOut.rateOverTime = 0f; 
          
            
            }
        }
    }

    if(greenFlag == 1)
  {
   if(readyFlag == 1)
   {
       initialGreen.SetActive(true);
       flask.GetComponent<MeshCollider>().enabled = false;

       

      // readyFlag = 0;
   }

        if(initialGreen.activeSelf && outGreen.activeSelf == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f && !outGreen.activeSelf)
            {
                outGreen.SetActive(true);
            }
        }
        if(outGreen.activeSelf && endFlag == 0)
        {
            timerEnd -= Time.deltaTime;
            if(timerEnd <= 0f)
            {   endFlag = 1;
                var emissionOut = outGreen.GetComponent<ParticleSystem>().emission;
              var emissionIn = initialGreen.GetComponent<ParticleSystem>().emission;
              var rendererIn = initialGreen.GetComponent<ParticleSystemRenderer>();

             float factor = Mathf.Pow(2,intensity);
             Debug.Log(factor);
            //  mat.SetColor("_Color", new Color(191f * factor,9f * factor,9f * factor, 1f));
            emissionIn.rateOverTime = 0f; 
            emissionOut.rateOverTime = 0f; 
          
            
            }
        }
    }

    }
}
