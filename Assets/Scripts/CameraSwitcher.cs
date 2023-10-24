using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    List<CinemachineVirtualCamera> vcams = new List<CinemachineVirtualCamera>();
    
    public void SwitchPriority(int cameraIndex)
    {
        for(int i = 0; i < vcams.Count; i++)
        {
            vcams[i].Priority = 0;
        }
        vcams[cameraIndex].Priority = 1;
    }
}
