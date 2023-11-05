using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedBackIntoButton : MonoBehaviour
{
    public GameObject button; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText()
    {
        if(button && GetComponent<TMP_InputField>().isFocused)
        {
            button.GetComponentInChildren<TMP_Text>().text = GetComponent<TMP_InputField>().text;
        }    
    }

}
