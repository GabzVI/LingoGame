﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void GoToScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}


    

