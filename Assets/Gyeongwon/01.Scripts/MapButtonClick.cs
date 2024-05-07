using UnityEngine;

public class MapButtonClick : MonoBehaviour
{
    public Camera mainCam;
    public GameObject MapPos;
    bool mapButtonClicked;
   


    private void Update()
    {
        if (mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, MapPos.transform.position, 0.01f);
        }
        else if (!mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, new Vector3(0,0,-10), 0.01f);
        }


    }
    public void clickWorldMap()
    {
            mapButtonClicked = true;
    }
    public void clickRobby()
    {
            mapButtonClicked = false;
    }

}
