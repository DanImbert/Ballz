using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation; // We need this namespace to access AR Foundation related classes and structs

// Script for testing what sort of light information the devices AR system supports
public class LightTester : MonoBehaviour
{
    // Reference tp the AR 
    [SerializeField] private ARCameraManager arCameraManager;

    // Text fields for displaying the lighting information values coming from the AR system to the user
    [SerializeField] private Text lightText0;
    [SerializeField] private Text lightText1;
    [SerializeField] private Text lightText2;
    [SerializeField] private Text lightText3;
    [SerializeField] private Text lightText4;
    [SerializeField] private Text lightText5;
    [SerializeField] private Text lightText6;

    /// <summary>
    /// The estimated brightness of the physical environment, if available.
    /// </summary>
    public float? brightness { get; private set; }
    /// <summary>
    /// The estimated color temperature of the physical environment, if available.
    /// </summary>
    public float? colorTemperature { get; private set; }
    /// <summary>
    /// The estimated color correction value of the physical environment, if available.
    /// </summary>
    public Color? colorCorrection { get; private set; }
    /// <summary>
    /// The estimated direction of the main light of the physical environment, if available.
    /// </summary>
    public Vector3? mainLightDirection { get; private set; }
    /// <summary>
    /// The estimated color of the main light of the physical environment, if available.
    /// </summary>
    public Color? mainLightColor { get; private set; }
    /// <summary>
    /// The estimated intensity in lumens of main light of the physical environment, if available.
    /// </summary>
    public float? mainLightIntensityLumens { get; private set; }
    /// <summary>
    /// The estimated spherical harmonics coefficients of the physical environment, if available.
    /// </summary>
    public SphericalHarmonicsL2? sphericalHarmonics { get; private set; }


    private void Start()
    {
        // Start listening for frame received events from the AR Camera
        // The event will be invoked at each ar camera frame update
        arCameraManager.frameReceived += FrameChanged;
    }

    // This script is run on each AR frame change
    void FrameChanged(ARCameraFrameEventArgs args)
    {
        // Display the value of average brightness if available
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            brightness = args.lightEstimation.averageBrightness.Value;
            lightText0.text = "Average Brightness: " + brightness;
        }
        // Display the value of average color temperature if available
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            colorTemperature = args.lightEstimation.averageColorTemperature.Value;
            lightText1.text = "Color temperature: " + colorTemperature;
        }
        // Display the value of color correction if available
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            colorCorrection = args.lightEstimation.colorCorrection.Value;
            lightText2.text = "Color correction: " + colorCorrection.ToString();
        }
        // Display the value of main light direction if available
        if (args.lightEstimation.mainLightDirection.HasValue)
        {
            mainLightDirection = args.lightEstimation.mainLightDirection;
            lightText3.text = "Light direction: " + mainLightDirection.ToString();
        }
        // Display the value of main light color if available
        if (args.lightEstimation.mainLightColor.HasValue)
        {
            mainLightColor = args.lightEstimation.mainLightColor;
            lightText4.text = "Main light color: " + mainLightColor.ToString();
        }
        // Display the value of main light intensity if available
        if (args.lightEstimation.mainLightIntensityLumens.HasValue)
        {
            mainLightIntensityLumens = args.lightEstimation.mainLightIntensityLumens;
            lightText5.text = "Main light intensity: " + mainLightIntensityLumens;
        }
        // Display the value of ambient spherical harmonics if available
        if (args.lightEstimation.ambientSphericalHarmonics.HasValue)
        {
            sphericalHarmonics = args.lightEstimation.ambientSphericalHarmonics;
            lightText6.text = "Spherical harmonics: " + sphericalHarmonics.ToString();
        }
    }
}
