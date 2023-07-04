using System.Collections.Generic;
using CodeBase.Camera;
using CodeBase.Platforms;
using CodeBase.Player;
using CodeBase.Points;
using CodeBase.Services.Input;
using CodeBase.Sounds;
using CodeBase.UI;
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
            var inputService = ConstructInputService();
            var player = ConstructPlayer(inputService);
            ConstructPoints(player);
            _platformSpawner.Construct(player);
            _camera.Construct(player);
            _hud.Construct(player.GetComponent<PlayerScore>());
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

        private void ConstructPoints(Transform player)
        {
            _losePoint.Construct(player);
            foreach (var sidePoint in _sidePoints)
                sidePoint.Construct(player);
        }
    }
}