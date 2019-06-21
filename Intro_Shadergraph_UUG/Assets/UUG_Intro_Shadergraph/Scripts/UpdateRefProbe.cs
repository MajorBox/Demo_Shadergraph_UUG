using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRefProbe : MonoBehaviour
{
    public ReflectionProbe rf;
    public float renderTime = 2.0f;
    RenderTexture targetTexture;
    private int RenderId = -1;

    IEnumerator Start()
    {
        rf = GetComponent<ReflectionProbe>();

        rf.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.AllFacesAtOnce;
        while (true)
        {
            yield return new WaitForSeconds(renderTime);

            RenderId = rf.RenderProbe(targetTexture);
        }
    }

    private void Update()
    {
        if(rf.IsFinishedRendering(RenderId))
        {
            rf.RenderProbe(targetTexture = null);
        }
    }

}