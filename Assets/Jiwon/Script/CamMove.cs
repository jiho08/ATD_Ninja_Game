using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject enemyCam2;
    [SerializeField] private GameObject PlayerCam3;

    private void Start()
    {
        cam1.SetActive(true);
        enemyCam2.SetActive(false);
        PlayerCam3.SetActive(false);
    }
    public IEnumerator EnemyCamMove()
    {
        cam1.SetActive(false);
        enemyCam2.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        cam1.SetActive(true);
        enemyCam2.SetActive(false);
    }

    public IEnumerator PlayerCamMove()
    {
        cam1.SetActive(false);
        PlayerCam3.SetActive(true);
        yield return new WaitForSecondsRealtime(6);
        cam1.SetActive(true);
        PlayerCam3.SetActive(false);
    }
}
