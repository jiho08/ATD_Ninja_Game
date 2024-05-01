using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceDir : MonoBehaviour
{
    WorldMapManager worldMapManager;
    float desiredAngle;
    RectTransform recTransform;
    Image image;
    public Sprite flag;
    public Sprite train;
    void Start()
    {
        worldMapManager = GameObject.Find("WorldMapManager").GetComponent<WorldMapManager>();
        recTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    private void Update()
    {
        SetFaceDir();
        AimTrain();
        if (transform.position == worldMapManager.GetCurrentStage().transform.position)
        {
            image.sprite = flag;
        }
        else
        {
            image.sprite = train;
        }
    }

    void AimTrain()
    {
        Vector3 aimDir = worldMapManager.GetCurrentStage().transform.position - transform.position;
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }
    void SetFaceDir()
    {
        if (desiredAngle < -90 || desiredAngle > 90)
        {
            recTransform.localScale = new Vector2(-0.5f, -0.5f);
        }
        else
        {
            recTransform.localScale = new Vector2(-0.5f, 0.5f);
        }
    }
}
