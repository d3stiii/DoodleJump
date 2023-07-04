using CodeBase.Data;

namespace CodeBase.Services.Data.SaveLoad
{
    public interface ISavedData
    {
        void LoadData(PlayerData data);
        void UpdateData(PlayerData data);
    }
}