
using UnityEngine;

public class AudioLoudness : MonoBehaviour
{
    public AudioSource magnetPulse;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;

    private float[] clipSampleData;

    public GameObject sprite;
    public float sizeFactor = 1;
    public float minSize;
    public float maxSize = 500;


    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    private void Update()
    {

        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            magnetPulse.clip.GetData(clipSampleData, magnetPulse.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
            sprite.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
        }
    }

}
