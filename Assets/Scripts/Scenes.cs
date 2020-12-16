using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void main_menu()
    {
        SceneManager.LoadScene(1);
    }
    public void main_game()
    {
        SceneManager.LoadScene(0);
    }
}
