using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetInputText : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInputField()
    {
        var text = GetComponentInChildren<TMP_Text>();
        inputField.text = text.text;
        inputField.GetComponentInParent<FeedBackIntoButton>().button = this.gameObject;
    }
}
