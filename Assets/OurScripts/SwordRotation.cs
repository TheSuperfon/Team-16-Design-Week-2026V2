using UnityEngine;

public class SwordRotation : MonoBehaviour
{

    [SerializeField] private GameObject sword;
    [SerializeField] private float angle = 90;
    [SerializeField] private float cooldown;

    [SerializeField] private bool readyToRotate;
    [SerializeField] private float currentTime;

    [SerializeField] public bool rotated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countUpTimer(cooldown);
        if (Input.GetKeyDown(KeyCode.E) && readyToRotate == true)
        {
            rotateSword(angle);
            currentTime = 0;
        }
    }


    private void countUpTimer(float cooldown)
    {
        currentTime += Time.deltaTime;

        if(currentTime >= cooldown)
        {
            readyToRotate = true;
            
        }

    }

    private void rotateSword(float angle)
    {
        Debug.Log("rotating");
        sword.transform.Rotate(angle,0,0);
        readyToRotate = false;
        rotated = !rotated;
    }

}
