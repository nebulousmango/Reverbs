using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject go_WinMenu;
    PlayerController playerController;
    int i_PlayerCount;

    private void Start()
    {
        go_WinMenu.SetActive(false);
    }

    /*
    private void Update()
    {
        if (i_PlayerCount == 2)
        {
            StartCoroutine(OpenWin());
        }
    }
    */

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<PlayerController>() == true)
        {
            playerController = other.GetComponentInChildren<PlayerController>();
            playerController.enabled = false;
            i_PlayerCount++;

            if (i_PlayerCount == 2)
            {
                StartCoroutine(OpenWin());
            }
        }
    }

    public IEnumerator OpenWin()
    {
        yield return new WaitForSeconds(1);
        go_WinMenu.SetActive(true);
    }
}
