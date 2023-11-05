using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
//using Input = ARFoundationRemote.Input;
#endif

public class GyroControlManager : MonoBehaviour
{
    // Start is called before the first frame update

    private bool _isGyroOn = false;
    private float _InitialGyroYAngle = 0f;
    private float _InitialCamYAngle = 0f;
    private bool _Calibrated = false;
    private bool _IsGyroAvailable = false;


    public void SwitchGyro()
    {
        _isGyroOn = !_isGyroOn;
        if (_isGyroOn)
        {
            _Calibrated = false;
        }
        else
        {
            RollCorrectionWhenSwitchingOffGyro();
        }
    }

    public void SwitchGyro(bool isOn)
    {
        if (!_IsGyroAvailable)
        {
            return;
        }
        _isGyroOn = isOn;
        if (_isGyroOn)
        {
            _Calibrated = false;
        }
        else
        {
            RollCorrectionWhenSwitchingOffGyro();
        }
    }

    public void RollCorrectionWhenSwitchingOffGyro()
    {
        Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);
    }

    private void OnEnable()
    {
        _IsGyroAvailable = SystemInfo.supportsGyroscope;
        if (!_IsGyroAvailable)
        {
            SwitchGyro(false);
            return;
        }
#if UNITY_ANDROID
        Input.gyro.enabled = true;
#endif
    }

    private void OnDisable()
    {
        _isGyroOn = false;
        RollCorrectionWhenSwitchingOffGyro();
#if UNITY_ANDROID
        Input.gyro.enabled = false;
#endif
    }

    protected void Update()
    {
        if (_isGyroOn)
        {
            GyroModifyCamera();
        }
    }


    /********************************************/

    
    void GyroModifyCamera()
    {
        if (!_Calibrated)
            _InitialCamYAngle = Camera.main.transform.eulerAngles.y;

        Camera.main.transform.rotation = Input.gyro.attitude;
        Camera.main.transform.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        Camera.main.transform.Rotate(90f, 180f, 0f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.

        if (!_Calibrated)
            _InitialGyroYAngle = Camera.main.transform.eulerAngles.y;


        Camera.main.transform.Rotate(0f, - (_InitialGyroYAngle - _InitialCamYAngle), 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
        //Camera.main.transform.rotation = GyroToUnity(Input.gyro.attitude);
        if(!_Calibrated)
            _Calibrated = true;

    }

    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
        //return  Quaternion.AngleAxis(-90, Vector3.right);
    }
}
