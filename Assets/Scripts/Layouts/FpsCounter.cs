using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.Layouts
{
    public class FpsCounter : MonoBehaviour
    {
        [SerializeField] Text fpsText;
        public float updateInterval = 0.5F;
        private float accum = 0;
        private int frames = 0;
        private float timeleft;

        void Awake()
        {
            fpsText = GetComponent<Text>();
        }

        void Start()
        {
            if (!fpsText)
            {
                enabled = false;
                return;
            }
            timeleft = updateInterval;
        }

        void Update()
        {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            ++frames;

            if (timeleft <= 0.0)
            {
                float fps = accum / frames;
                string format = System.String.Format("{0:F2} FPS", fps);
                fpsText.text = format;

                if (fps < 30)
                {
                    fpsText.color = Color.yellow;
                }
                else if (fps < 10)
                {
                    fpsText.color = Color.red;
                }
                else
                {
                    fpsText.color = Color.green;
                }
                timeleft = updateInterval;
                accum = 0.0F;
                frames = 0;
            }
        }
    }
}