using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameSceneManager : MonoBehaviour
{
   public void LoadSceneByName(string sceneName)
    {
        Time.timeScale = 1f;   

        StartCoroutine(ByNameSequence(sceneName));
    }      

      private IEnumerator ByNameSequence(string sceneName)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
