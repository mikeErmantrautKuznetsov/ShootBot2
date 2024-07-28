using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SceneLose(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SceneAdvertising(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
