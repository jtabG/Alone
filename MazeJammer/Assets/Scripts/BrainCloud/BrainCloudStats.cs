using UnityEngine;
using System.Collections;
using LitJson;

public class BrainCloudStats : MonoBehaviour 
{
    // global properties
    public float g_TrapResetTimer = 0.0f;

    public void ReadGlobalProperties()
    {
        BrainCloudWrapper.GetBC().GlobalAppService.ReadProperties(PropertiesSuccess_Callback, PropertiesFailure_Callback, null);
    }

    private void PropertiesSuccess_Callback(string responseData, object cbObject)
    {
        // Read the json and update our values
        JsonData jsonData = JsonMapper.ToObject(responseData);
        JsonData entries = jsonData["data"];

        g_TrapResetTimer = float.Parse(entries["BC_TrapResetTimer"]["value"].ToString());
    }

    private void PropertiesFailure_Callback(int a, int b, string responseData, object cbObject)
    {
        Debug.LogError(responseData);
    }
}
