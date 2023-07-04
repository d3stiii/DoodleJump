using System.Collections.Generic;
using CodeBase.Camera;
using CodeBase.Platforms;
using CodeBase.Player;
using CodeBase.Points;
using CodeBase.Services.Data;
using CodeBase.Services.Data.SaveLoad;
using CodeBase.Services.Input;
using CodeBase.Services.UI;
using CodeBase.Sounds;
using CodeBase.UI;
using CodeBase.UI.Windows;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Boot
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PlatformSpawner _platformSpawner;
        [SerializeField] private SoundPlayer _soundPlayer;
        [SerializeField] private CameraMovement _camera;
        [SerializeField] private LosePoint _losePoint;
        [SerializeField] private List<SidePoint> _sidePoints;
        [SerializeField] private ActorUI _hud;

        private void Awake()
        {
            var dataService = new DataService();
            var inputService = ConstructInputService();
            var player = ConstructPlayer(inputService);
            var windowService = new WindowService(_hud.transform, new WindowProvider(), dataService);
            _platformSpawner.Construct(player);
            _camera.Construct(player);
            _hud.Construct(player.GetComponent<PlayerScore>());
            var saveLoadService = ConstructSaveLoadService(new List<ISavedData> { player.GetComponent<PlayerScore>() },
                dataService);
            ConstructPoints(player, windowService, saveLoadService);
        }

        private SaveLoadService ConstructSaveLoadService(List<ISavedData> writers, DataService dataService)
        {
            var saveLoadService = new SaveLoadService(dataService);

            foreach (var writer in writers)
            {
                saveLoadService.RegisterWriter(writer);
            }

            saveLoadService.Load();

            return saveLoadService;
        }

        private IInputService ConstructInputService() =>
            Application.platform.IsStandalone() || Application.platform.IsEditor()
                ? new StandaloneInputService()
                : new MobileInputService();

        private Transform ConstructPlayer(IInputService inputService)
        {
            var player = Instantiate(_player, _spawnPoint.position, Quaternion.identity);
            player.GetComponent<PlayerSound>().Construct(_soundPlayer);
            player.GetComponent<SpriteFlipper>().Construct(inputService);
            player.Construct(inputService);

            return player.transform;
        }

        private void ConstructPoints(Transform player, WindowService windowService, SaveLoadService saveLoadService)
        {
            _losePoint.Construct(player);
            _losePoint.OnLose += () => windowService.Open(WindowId.GameOver);
            _losePoint.OnLose += player.GetComponent<PlayerMovement>().StopMovement;
            _losePoint.OnLose += saveLoadService.Save;

            foreach (var sidePoint in _sidePoints)
                sidePoint.Construct(player);
        }
    }
}