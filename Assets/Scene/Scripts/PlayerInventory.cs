using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    [SerializeField] private TMP_Text keyText;
    public int keys = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateKeyText();
    }

    public void AddKey()
    {
        keys++;
        UpdateKeyText();
    }

    public bool UseKey()
    {
        if (keys > 0)
        {
            keys--;
            UpdateKeyText();
            return true;
        }
        return false;
    }

    public void UpdateKeyText()
    {
        if (keyText != null)
        {
            keyText.text = keys.ToString();
        }
    }
}