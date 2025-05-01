using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public float volumeThreshold = 0.1f;
    public float sensitivity = 100.0f;
    private AudioClip micRecord;
    private string micName;
    private bool isLoud;

    void Start()
    {
        micName = Microphone.devices[0];
        micRecord = Microphone.Start(micName, true, 1, 44100);
    }

    void Update()
    {
        float loudness = GetMicVolume();
        isLoud = loudness > volumeThreshold;

        if (isLoud)
        {
            Debug.Log("Çýðlýk algýlandý!");
            // Buraya zýplama veya çýðlýk efekti gibi aksiyonlarý eklersin.
        }
    }

    float GetMicVolume()
    {
        int sampleWindow = 128;
        float[] data = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(micName) - sampleWindow + 1;

        if (micPosition < 0)
            return 0;

        micRecord.GetData(data, micPosition);
        float levelMax = 0;
        foreach (var sample in data)
        {
            float level = Mathf.Abs(sample);
            if (level > levelMax)
                levelMax = level;
        }

        return levelMax * sensitivity;
    }
}
