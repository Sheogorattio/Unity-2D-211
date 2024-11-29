using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{

    [SerializeField]
    private GameObject modalPanel;
    private static ModalScript instance;

     [SerializeField]
    private TMPro.TextMeshProUGUI titleTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;
    private string titleDefault;
    private string messageDefault;
    
    // Start is called before the first frame update
    void Start()
    {
        titleDefault =titleTMP.text;
        messageDefault = messageTMP.text;
        instance = this;
       if (  modalPanel.activeInHierarchy)Time.timeScale = .0f ;
    }

    // Update is called once per frame
    void Update()
    {
         if(GameState.isLevelCompleted){
            GameState.isLevelCompleted = false;
            ShowModal("Перемога", "Всіх ворогів знищено");           
        }
        if(Input.GetKeyUp(KeyCode.Escape)){         
            if(modalPanel.activeInHierarchy){
                modalPanel.SetActive(false);
                Time.timeScale = 1f ;                    
            }
            else{
                _Show();
            }
        }
        
    }

    public void OnResumeButtonClick(){
        Time.timeScale = 1.0f ;

        if(GameState.isFailed){
            GameState.isFailed = false;
            Debug.Log("inside of failed case");
            SceneManager.LoadScene(0);
        }
        else if(GameState.isLevelCompleted){
             Debug.Log("inside of copleted case");
            if (GameState.levelIndex == 0)
                SceneManager.LoadScene( "HW 1" );   
        }
        else{
             Debug.Log("inside of enemy destroyed case");
            Time.timeScale = modalPanel.activeInHierarchy? 1.0f : .0f;
            modalPanel.SetActive(! modalPanel.activeInHierarchy);    
        }
        Debug.Log("OnResumeButtonClick");
        
       
    }

    public void OnExitButtonClick(){
        Debug.Log("OnExitButtonClick");
        //UnityEditor.EditorApplication.isPlaying = false;
       Application.Quit();
    }

    private void _Show(string title=null, string message=null){
        Time.timeScale = .0f;
        modalPanel.SetActive(true);
        if(title != null){
            titleTMP.text = title;
        }
        if(message != null){
            messageTMP.text = message;
        }
    }

    public static void ShowModal (string title=null, string message=null){
        instance._Show( title, message);
    }
}
