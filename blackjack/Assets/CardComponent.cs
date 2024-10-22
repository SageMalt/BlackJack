using UnityEngine;
using UnityEngine.UI;

public class CardComponent : MonoBehaviour
{
    [SerializeField] Text textObj;

    public void SetName(string name)
    {
        textObj.text = name;
    }
}

