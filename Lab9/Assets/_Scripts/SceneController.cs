﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
public void OnButtonPressed()
    {
        SceneManager.LoadScene(scene);
    }
}