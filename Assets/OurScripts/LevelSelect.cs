using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public string tavernName;
    public string townName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTavern()
    {
        SceneManager.LoadScene(tavernName);



    }

    public void LoadTown()
    {

        SceneManager.LoadScene(townName);


    }

}
