using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameEngine;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class SaveLoadManager
{
    [ShowInInspector] private IEnumerable<ISaveLoader> _saveLoaders;
    [ShowInInspector] private Dictionary<string, string> _gameState;
    [ShowInInspector] private string saveFilePath;
    [ShowInInspector] private SaveLoadEncryptorDecryptor _saveLoadEncryptorDecryptor;

    public SaveLoadEncryptorDecryptor GetEncryptorDecryptor()
    {
        return _saveLoadEncryptorDecryptor;
    }

    [Inject]
    public SaveLoadManager(IEnumerable<ISaveLoader> saveLoaders, SaveLoadEncryptorDecryptor saveLoadEncryptorDecryptor)
    {
        _saveLoaders = saveLoaders;
        _saveLoadEncryptorDecryptor = saveLoadEncryptorDecryptor;
    }

    public void SetSaveFilePath(string filePath)
    {
        saveFilePath = filePath;
    }

    [Button]
    public void SaveGame()
    {
        _gameState = new Dictionary<string, string>();
        foreach (var saveLoader in _saveLoaders)
        {
            _gameState.Add(saveLoader.GetType().ToString(),saveLoader.Save());
        }

        var text = JsonConvert.SerializeObject(_gameState);
        
        var encryptedTextBytes = _saveLoadEncryptorDecryptor.EncryptStringToBytes_Aes(text);
        
        File.WriteAllBytes(saveFilePath,encryptedTextBytes);      
    }

    [Button]
    public void LoadGame()
    {
        var file = File.ReadAllBytes(saveFilePath);

        var decryptedTExt = _saveLoadEncryptorDecryptor.DecryptStringFromBytes_Aes(file);
        Debug.Log(decryptedTExt);

        var gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(decryptedTExt);
        
        foreach (var saveLoader in _saveLoaders)
        {
            foreach (var recording in gameState)
            {
                if (saveLoader.GetType().ToString() == recording.Key)
                {
                    saveLoader.Load(recording.Value);
                }
            }
        }
    }
}
