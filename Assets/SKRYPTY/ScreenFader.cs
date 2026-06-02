using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
   public static ScreenFader Instance;
   [SerializeField] CanvasGroup canvasGroup;
   [SerializeField] float fadeDuration = 0.5f;

   private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    async Task Fade(float targetTransparency)
    {
        float start = canvasGroup.alpha, t = 0; //t for time
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, targetTransparency, t / fadeDuration);
            await Task.Yield();
        }
        canvasGroup.alpha = targetTransparency;
    }

    public async Task FadeToBlack()
    {
        await Fade(1); //fade to black
    }

    public async Task FadeToTransparent()
    {
        await Fade(0); //fade to transparent
    }
}
