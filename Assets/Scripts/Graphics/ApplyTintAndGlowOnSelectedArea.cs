using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ApplyTintAndGlowOnSelectedArea : MonoBehaviour {

    public Material BrightFilterMat;
    [Range(0, 6)]
    public int DownRes = 0;
    [Range(0, 6)]
    public int ciclos = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture brightRT = RenderTexture.GetTemporary(source.width, source.height);
        // Apply Bright filter to render image
        Graphics.Blit(source, brightRT, BrightFilterMat);

        // Apply Mean Blur filter to brigth filter image
        // MeanBlurApply(source, destination);

        // About image scaling https://goo.gl/bi2fPV
        //int width = source.width >> MeanBlurDownRes;
        //int height = source.height >> MeanBlurDownRes;

        /*
         * This method can not be used because RenderTexture.GetTemporary() requires two int arguments
         * for specify the width and the heigh and if we cast the DownRes2 variable which is a float from 0 to 1
         * width and height only will be in two posible values 0 and source.width
        int width = source.width * DownRes2;
        int height = source.height * DownRes2;
        */
        /*
        
        RenderTexture blurRt = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(source, blurRt);
        for (int i = 0; i < MeanBlurCycles; i++)
        {
            //Debug.Log("Blur Cycle: " + (i+1));
            RenderTexture rt2 = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(blurRt, rt2, MeanBlurMat);
            RenderTexture.ReleaseTemporary(blurRt);
            blurRt = rt2;
*/
            /* We cannot do:
             * RenderTexture.ReleaseTemporary(rt2)
             * 
             * Because RenderTexture, then it is a reference
             * in blurRt to rt2, then we are erasing the blurred image
             * before we 'Blit' with the destination image.
             */
        //}

        //Graphics.Blit(blurRt, destination);
        // RenderTexture.ReleaseTemporary(blurRt);

        // RenderTexture.ReleaseTemporary(brightRT);

        // About image scaling https://goo.gl/bi2fPV
        int width = source.width >> DownRes;
        int height = source.height >> DownRes;

        /*
         * This method can not be used because RenderTexture.GetTemporary() requires two int arguments
         * for specify the width and the heigh and if we cast the DownRes2 variable which is a float from 0 to 1
         * width and height only will be in two posible values 0 and source.width
        int width = source.width * DownRes2;
        int height = source.height * DownRes2;
        */

        RenderTexture blurRT = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(brightRT, blurRT);

        /*for (int i = 0; i < ciclos; i++)
        {
            RenderTexture rt2 = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(rt, rt2, blurMaterial);
            RenderTexture.ReleaseTemporary(rt);
            rt = rt2;
        }*/

        Graphics.Blit(blurRT, destination);


        RenderTexture.ReleaseTemporary(blurRT);
        RenderTexture.ReleaseTemporary(brightRT);
    }


    /*
    public void MeanBlurApply(RenderTexture source, RenderTexture destination)
    {
        // About image scaling https://goo.gl/bi2fPV
        int width = source.width >> MeanBlurDownRes;
        int height = source.height >> MeanBlurDownRes;
        */
        /*
         * This method can not be used because RenderTexture.GetTemporary() requires two int arguments
         * for specify the width and the heigh and if we cast the DownRes2 variable which is a float from 0 to 1
         * width and height only will be in two posible values 0 and source.width
        int width = source.width * DownRes2;
        int height = source.height * DownRes2;
        */
        /*
        RenderTexture blurRt = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(source, blurRt);
        for (int i = 0; i < MeanBlurCycles; i++)
        {*/
           /* RenderTexture rt2 = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(blurRt, rt2, MeanBlurMat);
            RenderTexture.ReleaseTemporary(blurRt);
            blurRt = rt2;*/
            /* We cannot do:
             * RenderTexture.ReleaseTemporary(rt2)
             * 
             * Because RenderTexture, then it is a reference
             * in blurRt to rt2, then we are erasing the blurred image
             * before we 'Blit' with the destination image.
             */
        /*}

        Graphics.Blit(blurRt, destination);
        RenderTexture.ReleaseTemporary(blurRt);
    }*/
}
