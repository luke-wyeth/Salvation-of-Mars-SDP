using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Update is called once per frame
    //When the user presses the R key, it will reload the current level it is in
    //Gravity resets back to normal
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Restart"))
        {
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -(Mathf.Abs(Physics2D.gravity.y)));

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
