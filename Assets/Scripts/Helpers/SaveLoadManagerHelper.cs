using System;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class SaveLoadManagerHelper : MonoBehaviour
{
    [SerializeField][FolderPath] private string saveFileFolder;
    [SerializeField] private string saveFileName;
    [ShowInInspector] private SaveLoadManager _saveLoadManager;
    [SerializeField] private byte[] encryptionKey, encryptionIV;
    

    [Inject]
    public void Construct(SaveLoadManager saveLoadManager)
    {
        _saveLoadManager = saveLoadManager;
    }

    private void Start()
    {
        _saveLoadManager.SetSaveFilePath(saveFileFolder+"/"+saveFileName);
        var encryptor = _saveLoadManager.GetEncryptorDecryptor();
        encryptor.SetKey(encryptionKey);
        encryptor.SetIV(encryptionIV);
    }
}
