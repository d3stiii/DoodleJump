using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Extensions.Data;
using UnityEngine;

namespace CodeBase.Services.Data.SaveLoad
{
    public class SaveLoadService
    {
        private const string DataKey = "Save";
        private readonly List<ISavedData> _dataWriters = new();
        private readonly DataService _dataService;

        public SaveLoadService(DataService dataService) =>
            _dataService = dataService;

        public void Load()
        {
            _dataService.Data = PlayerPrefs.GetString(DataKey).ToDeserialized<PlayerData>() ?? new PlayerData();

            foreach (var writer in _dataWriters)
            {
                writer.LoadData(_dataService.Data);
            }
        }

        public void Save()
        {
            foreach (var writer in _dataWriters)
            {
                writer.UpdateData(_dataService.Data);
            }

            PlayerPrefs.SetString(DataKey, _dataService.Data.ToJson());
        }

        public void RegisterWriter(ISavedData writer) =>
            _dataWriters.Add(writer);

        public void RemoveWriter(ISavedData writer) =>
            _dataWriters.Remove(writer);
    }
}