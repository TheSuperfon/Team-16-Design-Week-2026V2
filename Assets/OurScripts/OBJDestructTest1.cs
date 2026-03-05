using UnityEngine;

public class OBJDestructTest1 : MonoBehaviour
{
    GameObject NotBrokenObj;
    GameObject BrokenObj;
    bool isBottle;
    bool isBroken;
    bool isWallMounted;
    AudioSource audiosource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        NotBrokenObj = this.gameObject.transform.GetChild(0).gameObject;
        BrokenObj = this.gameObject.transform.GetChild(1).gameObject;
        NotBrokenObj.SetActive(true);
        BrokenObj.SetActive(false);
        if ((this.gameObject.transform.GetChild(0).gameObject.name == "bottleFull") || (this.gameObject.transform.GetChild(0).gameObject.name == "fish-large"))
        {
            isBottle = true;
        }


        if ((this.gameObject.transform.GetChild(0).gameObject.name == "banner-red"))
        {
            isWallMounted = true;
        }
        else
        {
            isWallMounted= false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (!isBroken)
        {
            if (collision.gameObject.name == "Sword")
            {
                NotBrokenObj.SetActive(false);
                BrokenObj.SetActive(true);
                //collision.transform.parent.transform.parent.gameObject.GetComponent<AudioAttempt>().playsound();
                collision.gameObject.GetComponent<AudioAttempt>().playsound();
                audiosource.Play();
                isBroken = true;
                if (isWallMounted)
                {
                    this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
            }

            

            if (isBottle)
            {
                if (collision.gameObject.name == "Ground")
                {
                    NotBrokenObj.SetActive(false);
                    BrokenObj.SetActive(true);
                    audiosource.Play();
                    isBroken = true;
                }
            }
        }

        

    }


}
