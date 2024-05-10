using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Baek.Utile
{
    public class CameraUtile
    {
        public static void CameraShake(CinemachineVirtualCamera _cinemachineTrm, Vector3 offSet, float amplitude, float frequency)
        {

            var _cam = _cinemachineTrm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            _cam.m_PivotOffset = new Vector3(offSet.x, offSet.y, offSet.z);
            _cam.m_AmplitudeGain = amplitude;
            _cam.m_FrequencyGain = frequency;
        }


    }


}
