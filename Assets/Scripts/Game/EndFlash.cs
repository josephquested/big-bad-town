using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;

 public class EndFlash : MonoBehaviour {
     private Texture2D pixel;
     public Color color = Color.white;
     public float startAlpha=0.0f;
     public float maxAlpha=1.0f;
     public float rampUpTime=0.5f;
     public float holdTime=0.5f;
     public float rampDownTime=0.5f;

     enum FLASHSTATE {OFF,UP,HOLD,DOWN}
     Timer timer;
     FLASHSTATE state = FLASHSTATE.OFF;


     // Use this for initialization
     void Start(){
         pixel = new Texture2D(1,1);
         color.a = startAlpha;
         pixel.SetPixel(0,0,color);
         pixel.Apply();
				 StartCoroutine(FlashRoutine());
     }

		 IEnumerator FlashRoutine ()
		 {
			 TookDamage();
			 yield return new WaitForSeconds(0.5f);
			 TookDamage();
			 yield return new WaitForSeconds(0.5f);
			 TookDamage();
			 yield return new WaitForSeconds(0.5f);
			 holdTime = 10000f;
			 TookDamage();
			 yield return new WaitForSeconds(1f);
       EndItAll();
		 }

     public void EndItAll ()
     {
       GameObject player = GameObject.FindWithTag("Player");
       player.GetComponent<SpriteRenderer>().enabled = false;
       player.GetComponent<PlayerInput>().enabled = false;
       player.transform.position = Vector3.zero;
       GameObject.FindWithTag("MainCamera").transform.position = new Vector3(0, 0, -10);
       GameObject.FindWithTag("HUD").SetActive(false);
       SetWinTime();
       SceneManager.LoadScene("credits");
     }

     void SetWinTime ()
     {
       GameObject player = GameObject.FindWithTag("Player");

       if (PlayerPrefs.GetInt("winTime") == 0)
       {
         PlayerPrefs.DeleteAll();
         PlayerPrefs.SetInt("winTime", player.GetComponent<GameTimer>().gameTime);
       }
       else
       {
         if (PlayerPrefs.GetInt("winTime") > player.GetComponent<GameTimer>().gameTime)
         {
           PlayerPrefs.DeleteAll();
           PlayerPrefs.SetInt("winTime", player.GetComponent<GameTimer>().gameTime);
         }
         else
         {
           int oldTime = PlayerPrefs.GetInt("winTime");
           PlayerPrefs.DeleteAll();
           PlayerPrefs.SetInt("winTime", oldTime);
         }
       }
     }

     public void Update() {
         switch(state){
             case FLASHSTATE.UP:
                 if (timer.UpdateAndTest()){
                     state =FLASHSTATE.HOLD;
                     timer = new Timer(holdTime);
                 }
                 break;
             case FLASHSTATE.HOLD:
                 if (timer.UpdateAndTest()){
                     state =FLASHSTATE.DOWN;
                     timer = new Timer(rampDownTime);
                 }
             break;
             case FLASHSTATE.DOWN:
                 if (timer.UpdateAndTest()){
                     state =FLASHSTATE.OFF;
                     timer = null;
                 }
             break;
         }
     }

     private void SetPixelAlpha(float a){
         color.a = a;
         pixel.SetPixel(0,0,color);
         pixel.Apply();
     }

     public void OnGUI(){
         switch(state){
             case FLASHSTATE.UP:
                 SetPixelAlpha(Mathf.Lerp(startAlpha,maxAlpha,timer.Elapsed));
                 break;
             case FLASHSTATE.DOWN:
                 SetPixelAlpha(Mathf.Lerp(maxAlpha,startAlpha,timer.Elapsed));
                 break;
         }
         GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), pixel);
     }

     public void TookDamage(){
         timer = new Timer(rampUpTime);
         state = FLASHSTATE.UP;
     }

 }
