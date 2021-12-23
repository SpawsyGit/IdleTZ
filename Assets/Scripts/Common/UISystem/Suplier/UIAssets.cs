using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
        fileName = "UIAssets",
        menuName = "UI/New UIAssets"
    )]
public class UIAssets : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private UIInfo[] UIInfos = new UIInfo[0];
    private Dictionary<UITypes, string> uiPathMap;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        var count = this.UIInfos.Length;
        this.uiPathMap = new Dictionary<UITypes, string>(count);
        for (var i = 0; i < count; i++)
        {
            var info = this.UIInfos[i];
            var uiId = info.uiName;

        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
    }


    [Serializable]
    private sealed class UIInfo
    {
        [SerializeField]
        public UITypes uiName;

        [SerializeField]
        public GameObject uiPrefab;

    }
}
