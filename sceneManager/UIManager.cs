using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public RectTransform Console;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F12))
        {
            if (!Console.gameObject.activeSelf)
                StartCoroutine(GrowUp());
            else
                StartCoroutine(GetDown());
        }
    }
    
    IEnumerator GetDown()
    {
        while (Console.localScale.y >= 0)
        {
            Console.localScale = new Vector3(Console.transform.localScale.x, Console.transform.localScale.y - 0.1f, Console.transform.localScale.z);
            yield return new WaitForSeconds(0.1f);
        }
        Console.gameObject.SetActive(!Console.gameObject.activeSelf);
    }

    IEnumerator GrowUp()
    {
        Console.gameObject.SetActive(!Console.gameObject.activeSelf);
        while (Console.localScale.y <= 0.9f)
        {
            Console.transform.localScale = new Vector3(Console.transform.localScale.x, Console.transform.localScale.y + 0.1f, Console.transform.localScale.z);
            Console.transform.localScale = new Vector3(Console.transform.localScale.x, Mathf.Clamp(Console.transform.localScale.y + 0.1f, 0, 1), Console.transform.localScale.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
