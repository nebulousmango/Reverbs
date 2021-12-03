using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameSaveData latestSaveData, defaultSaveData;
    public Transform presentPlayer, futurePlayer;

    public bool autoSave;

    public float saveInterval;
    private Sequence _timedSave;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    void Start()
    {
        presentPlayer.localPosition = latestSaveData.presentPlayerPosition;
        futurePlayer.localPosition = latestSaveData.futurePlayerPosition;
        
        if(autoSave == true)
        {
            CreateAutoSaveSequence();
        }
        
    }

    public void SaveGameState()
    {
        latestSaveData.presentPlayerPosition = presentPlayer.localPosition;
        latestSaveData.futurePlayerPosition = futurePlayer.localPosition;
    }

    public void CreateAutoSaveSequence()
    {
        _timedSave = DOTween.Sequence();

        _timedSave.PrependInterval(saveInterval);
        _timedSave.AppendCallback(SaveGameState);
        _timedSave.SetLoops(-1, LoopType.Restart);

        _timedSave.Play();
    }

    public void LoadDefaultSaveData()
    {
        presentPlayer.localPosition = defaultSaveData.presentPlayerPosition;
        futurePlayer.localPosition = defaultSaveData.futurePlayerPosition;
    }

}
