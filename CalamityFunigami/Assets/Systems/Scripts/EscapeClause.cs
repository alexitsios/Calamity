using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeClause : MonoBehaviour
{
    void Awake() => DontDestroyOnLoad(gameObject);

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

}
