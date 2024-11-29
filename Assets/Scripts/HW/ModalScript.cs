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
    [SerializeField]
    private TMPro.TextMeshProUGUI resumeButtonText;
    
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
        if(Input.GetKeyUp(KeyCode.Escape)){         
            if(modalPanel.activeInHierarchy){
                modalPanel.SetActive(false);
                Time.timeScale = 1f ;                    
            }
            else{
                _Show();
            }
        }
        if(GameState.isFailed){
            resumeButtonText.text = "Cпочакту";
        }
        else if(GameState.isLevelCompleted){
             resumeButtonText.text = "Перепройти";
             GameState.isLevelCompleted = false;
             ShowModal("Перемога", "Всіх ворогів знищено");   
        }
        else{
            resumeButtonText.text = "Продовжити";
        }
    }

    private void startAgain(){
        GameState.isFailed = false;
            Debug.Log("inside of failed case");
            SceneManager.LoadScene(0);
    }

    private void redoLevel(){
        SceneManager.LoadScene(GameState.levelIndex);
    }

    public void OnResumeButtonClick(){
        Time.timeScale = 1.0f ;

        if(GameState.isFailed){
            startAgain();
        }
        else if(GameState.isLevelCompleted){
           redoLevel();  
        }
             Debug.Log("inside of enemy destroyed case");
            Time.timeScale = modalPanel.activeInHierarchy? 1.0f : .0f;
            modalPanel.SetActive(! modalPanel.activeInHierarchy);    
       
        Debug.Log("OnResumeButtonClick");
        
       
    }

    public void OnCancelButtonClick(){
        Time.timeScale= 1.0f;
        Time.timeScale = modalPanel.activeInHierarchy? 1.0f : .0f;
            modalPanel.SetActive(! modalPanel.activeInHierarchy);    
        if(GameState.isFailed){
            startAgain();
        }
        else if(GameState.isLevelCompleted){
           
             Debug.Log("inside of copleted case");
            if (GameState.levelIndex <= 2){
                GameState.levelIndex++;
                       
            }
            else{
                GameState.levelIndex =0;
            }
            Debug.Log("Level index is: " + GameState.levelIndex);
            SceneManager.LoadScene(GameState.levelIndex);   
                
        }
             Debug.Log("inside of enemy destroyed case");
            
        
    }

    public void OnExitButtonClick(){
        Debug.Log("OnExitButtonClick");
        //UnityEditor.EditorApplication.isPlaying = false;
       Application.Quit();
    }

    private enum AllowedConuationStatus {
        ReloadLevel=-1,
        Continue,
        Redo
    }
    private void _Show(string title=null, string message=null, AllowedConuationStatus status=0){
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
