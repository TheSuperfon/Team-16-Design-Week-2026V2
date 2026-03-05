using UnityEngine;

public class SwordPosTestScript1 : MonoBehaviour
{
    public GameObject EmptySword;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = EmptySword.transform.position;
        //gameObject.transform.rotation = EmptySword.transform.rotation;
    }


}
