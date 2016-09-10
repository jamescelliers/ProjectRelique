using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour {

    public enum PlayMode {Loop, RubberBand }
    public PlayMode Mode = PlayMode.Loop;
    public Sprite[] SpriteList;
    private SpriteRenderer sr;
    private int currentIndex = 0;
    public float playRate = 1.0f;
    private float timer = 0.0f;
    public bool IsPlaying { get; private set; }
    private bool inReverse = false;
    public bool PlayOnStart = false;

    // Use this for initialization
    void Start () {
        if (GetComponent<SpriteRenderer>())
        {
            sr = GetComponent<SpriteRenderer>();
        }else
        {
            sr = gameObject.AddComponent<SpriteRenderer>();
        }
        if (SpriteList != null)
        {
            sr.sprite = SpriteList[currentIndex];
        }
        if (PlayOnStart)
        {
            Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (IsPlaying)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            if (timer <= 0)
            {

                if (currentIndex == (SpriteList.Length - 1))
                {
                    if (Mode == PlayMode.Loop)
                    {
                        currentIndex = 0;
                    }
                    else
                    {
                        inReverse = true;
                        currentIndex = SpriteList.Length - 2;
                    }
                }
                else
                if (currentIndex == 0 && inReverse == true)
                {
                    currentIndex = 1;
                    inReverse = false;
                }
                else
                {
                    if (!inReverse)
                        currentIndex++;
                    else
                        currentIndex--;
                }

                sr.sprite = SpriteList[currentIndex];
                timer = playRate;
            }
        }
    }

    public void SetSprites(Sprite[] sprites)
    {
        SpriteList = sprites;
        sr.sprite = SpriteList[currentIndex];
    }

    public void Play()
    {
        IsPlaying = true;
    }

    public void Stop()
    {
        IsPlaying = false;
    }
}
