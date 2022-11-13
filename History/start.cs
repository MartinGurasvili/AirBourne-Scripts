using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sd());
    }

    IEnumerator sd()
    {
        yield return new WaitForSeconds(3.3f);
        SceneManager.LoadScene(1);


    }
}
