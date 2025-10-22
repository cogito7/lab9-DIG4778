using LitJson;
using UnityEngine;

public class TransformSaver : MonoBehaviour, ISaveable
{
    public string _saveID;

    private const string LOCAL_POSITION_KEY = "localPosition";
    private const string LOCAL_ROTATION_KEY = "localRotation";
    private const string LOCAL_SCALE_KEY = "localScale";
    private JsonData SerializeValue(object obj) {
        return JsonMapper.ToObject(JsonUtility.ToJson(obj));
    }

    public JsonData SavedData
    {
        get
        {
            var result = new JsonData();
            result[LOCAL_POSITION_KEY] = SerializeValue(transform.localPosition);
            result[LOCAL_ROTATION_KEY] = SerializeValue(transform.localRotation);
            result[LOCAL_SCALE_KEY] = SerializeValue(transform.localScale);
            return result;
        }
    }

    public void LoadFromData(JsonData data)
    {
        var x = data[LOCAL_POSITION_KEY];
        if (data.ContainsKey(LOCAL_POSITION_KEY)) { transform.localPosition = JsonMapper.ToObject<Vector2>(data[LOCAL_POSITION_KEY].ToJson()); }
        if (data.ContainsKey(LOCAL_ROTATION_KEY)) { transform.localRotation = JsonMapper.ToObject<Quaternion>(data[LOCAL_ROTATION_KEY].ToJson()); }
        if (data.ContainsKey(LOCAL_SCALE_KEY)) { transform.localScale = JsonMapper.ToObject<Vector3>(data[LOCAL_SCALE_KEY].ToJson()); }
    }

    public string SaveID
    {
        get {
            if (_saveID == null)
            {
                _saveID = System.Guid.NewGuid().ToString();
            }
            return _saveID;
        }
        set { _saveID = value; }
    }
    public void OnBeforeSerialize()
    {
        if (_saveID == null)
        {
            _saveID = System.Guid.NewGuid().ToString();
        }
    }
    public void OnAfterDeserialize()
    {
    }
}
