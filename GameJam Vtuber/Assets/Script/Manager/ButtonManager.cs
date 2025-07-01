using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    
    void Awake()
    {
        //allButtons = GameObject.FindObjectsOfType<Button>();
        if (Instance == null) Instance = this;
    }

     
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TriggerFirstActiveButton("Interact");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TriggerFirstActiveButton("Exit");
        }
    
    }

    void TriggerFirstActiveButton(string prefix)
    {
        Button[] allButtons = GameObject.FindObjectsOfType<Button>(true); // include inactive
        foreach (Button btn in allButtons)
        {
            GameObject go = btn.gameObject;
            if (go.name.StartsWith(prefix) && go.activeInHierarchy && btn.interactable)
            {
                Debug.Log("Menekan tombol: " + go.name);
                btn.onClick.Invoke();
                break; // hanya trigger 1 tombol pertama yang cocok
            }
        }
    }
}
