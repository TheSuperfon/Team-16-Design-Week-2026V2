using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public string tavernName;
    public string townName;
    public string ResetToTitle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void LoadTavern()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(tavernName);



    }

    public void ResetButton()
    {
        SceneManager.LoadScene(ResetToTitle);



    }

    public void LoadTown()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(townName);


    }

}
