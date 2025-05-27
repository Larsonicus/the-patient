using UnityEngine;
using UnityEngine.SceneManagement;
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
            SceneManager.sceneLoaded += OnSceneLoaded;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        keyText = GameObject.Find("Keys")?.GetComponent<TMP_Text>();

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