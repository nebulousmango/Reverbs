using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Jun Tween/Tween Runtime")]
public class Jun_TweenRuntime : MonoBehaviour 
{
	#region<Play Setting>
	[System.Serializable]
	public class OnFinish : UnityEvent{}
	[SerializeField] OnFinish m_onFinish;

	public enum PlayType
	{
		Deful,
		One,
		Loop,
		PingPong
	}

	public PlayType playType = PlayType.Deful;
	public float animationTime = 1.0f;

	public bool enablePlay = false;
	public bool awakePlay = true;
	public bool lgnoreTimeScale = true;
    public bool randomStartValue = false;

    [Range(0, 1)]
    public float startValue = 0;
	private float playTimeNote;
	private bool isPing = true;//true to ping，false to pong

	public float currentTimeValue
	{
		get
		{
			if(!isPlaying)
				return 0;

			float curTimeLenght = lgnoreTimeScale? (Time.time - playTimeNote):(Time.unscaledTime - playTimeNote);
			float curValue = curTimeLenght/animationTime;

			if(!isPing)
			{
				curValue = 1 - curValue;
				if(curValue <= 0)
				{
					StopPlay ();
				}
			}
			else
			{
				if(curValue >= 1)
				{
					StopPlay ();
				}
			}

			if(_isRewind)
			{
				curValue = 1 - curValue;
			}

			curValue = curValue < 0?0:curValue;
			curValue = curValue > 1?1:curValue;

			return curValue;
		}
	}
	#endregion

	[Range (0f,1f)]
	[HideInInspector][SerializeField]float _previewValue;
	public float previewValue
	{
		get{return _previewValue;}
		set
		{
			if(_previewValue != value)
			{
			    if(_previewValue == 0)
				{
					Init ();
					Play ();
				}
				_previewValue = value;
				PlayAtTime (_previewValue);
			}
		}
	}

	[HideInInspector][SerializeField]List<Jun_Tween> tweens = new List<Jun_Tween>();
	public Jun_Tween firstTween
	{
		get
		{
			if(tweens.Count > 0)
				return tweens[0];
			return null;
		}
	}

	bool _isPlaying = false;
	bool _isRewind = false;
	public bool isPlaying {get{return _isPlaying;}}

	void Awake ()
	{
		Init ();
		if(awakePlay)
		{
			Play ();
		}
	}

	void Init ()
	{
		foreach (Jun_Tween thisTween in tweens)
		{
            thisTween.Init (transform);
		}

		if (randomStartValue)
			startValue = Random.Range(0.0f, 1.0f);
	}

	void OnEnable()
	{
		if(enablePlay)
			Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isPlaying)
		{
			PlayAtTime (currentTimeValue);
		}
	}

	//Note Animation time
	void NoteTime ()
	{
        if (!lgnoreTimeScale)
        {
            playTimeNote = Time.unscaledTime;
        }
        else
        {
            playTimeNote = Time.time;
        }
	}

	public void Play ()
	{
		_isRewind = false;

		PlayAnimation ();
        playTimeNote -= animationTime * startValue;
	}

	public void Rewind ()
	{
		_isRewind = true;
		PlayAnimation ();

        playTimeNote -= animationTime * startValue;
	}

	public void PlayAtTime (float curveValue)
	{
		foreach (Jun_Tween thisTween in tweens)
		{
			if(curveValue >= thisTween.minAnimationTime && curveValue <= thisTween.maxAnimationTime)
			{
				float thisValue = (curveValue - thisTween.minAnimationTime)/(thisTween.maxAnimationTime - thisTween.minAnimationTime);
				thisTween.PlayAtTime (thisValue);
			}
		}
	}

	void PlayAnimation ()
	{      
		_isPlaying = true;
		this.enabled = true;
		NoteTime ();
	}

	//Stop Play
	public virtual void StopPlay ()
	{
		switch (playType)
		{
			case PlayType.Deful:
			case PlayType.One:
				_isPlaying = false;
				this.enabled = false;
				m_onFinish.Invoke();

				break;

			case PlayType.Loop:
				NoteTime();
				break;

			case PlayType.PingPong:
				NoteTime();
				isPing = !isPing;
				break;
		}
	}

	public void AddOnFinished (UnityAction call)
	{
		m_onFinish.AddListener (call);
	}

	public void ClearOnFinished ()
	{
		m_onFinish.RemoveAllListeners ();
	}

	public void SetFirstTweenValue (Vector3 setFromVector,Vector3 setToVector)
	{
		Jun_Tween thisFirstTween = firstTween;
		if(thisFirstTween != null)
		{
			thisFirstTween.SetValue (setFromVector,setToVector);
		}
	}

	public void SetFirstTweenValue (Color setFromColor,Color setToColor)
	{
		Jun_Tween thisFirstTween = firstTween;
		if(thisFirstTween != null)
		{
			thisFirstTween.SetValue (setFromColor,setToColor);
		}
	}

	public void SetFirstTweenValue (float setFromFloat,float setToFloat)
	{
		Jun_Tween thisFirstTween = firstTween;
		if(thisFirstTween != null)
		{
			thisFirstTween.SetValue (setFromFloat,setToFloat);
		}
	}

    public void SetTweenValue (int index,Vector3 setFromVector,Vector3 setToVector)
    {
        if(index < tweens.Count && index >= 0)
        {
            tweens[index].SetValue(setFromVector, setToVector);
        }
    }

    public void SetTweenValue(int index, Color setFromColor, Color setToColor)
    {
        if (index < tweens.Count && index >= 0)
        {
            tweens[index].SetValue(setFromColor, setToColor);
        }
    }

    public void SetTweenValue(int index, float setFromFloat, float setToFloat)
    {
        if (index < tweens.Count && index >= 0)
        {
            tweens[index].SetValue(setFromFloat, setToFloat);
        }
    }

    public Jun_Tween GetTween (int index)
    {
        if (index < tweens.Count && index >= 0)
        {
            return tweens[index];
        }
        return null;
    }
}
