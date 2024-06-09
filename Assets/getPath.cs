using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class getPath : MonoBehaviour
{
    public TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        string _filePath = Path.Combine(Application.persistentDataPath, "fileName");
        text.text = _filePath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
