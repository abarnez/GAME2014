using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((enemy1 == null) && (enemy2 == null) && (enemy3==null) && (enemy4 == null) && (enemy5 == null))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
