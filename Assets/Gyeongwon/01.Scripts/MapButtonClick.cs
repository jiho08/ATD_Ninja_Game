using UnityEngine;

public class MapButtonClick : MonoBehaviour
{
    [SerializeField] toMainMenuSO toMainSO;
    public Camera mainCam;
    public GameObject MapPos;
    bool mapButtonClicked;
   


    private void Update()
    {
        if (mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, MapPos.transform.position, 0.01f);
        }
        else if (toMainSO.DidEndGame == true)
        {
            mainCam.transform.position = MapPos.transform.position;
            toMainSO.DidEndGame = false;
            mapButtonClicked = true;
        }
        else if (!mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, new Vector3(0,0,-10), 0.01f);
        }

    }
    public void clickWorldMap()
    {
        mapButtonClicked = true;

        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
    }
    public void clickRobby()
    {
        mapButtonClicked = false;

        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
    }

}
