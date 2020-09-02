using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;

namespace F.PoliceOnUI
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("F.PoliceOn Loaded", ConsoleColor.Red);
            Logger.Log("F.Plugins Discord: https://discord.gg/4FF2548", ConsoleColor.Yellow);

            U.Events.OnPlayerConnected += OnPlayerConnected;
            U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
        }

        public int Policia;
        

        private void OnPlayerConnected(UnturnedPlayer player)
        {
            EffectManager.sendUIEffect(27410, 27410, true, Policia.ToString());

            if (player.IsAdmin)
            {
                return;
            }
            else if (player.HasPermission(this.Configuration.Instance.PolicePermission))
            {
                Policia = Policia + 1;
            }

            EffectManager.sendUIEffect(27410, 27410, true, Policia.ToString());
        }

        private void OnPlayerDisconnected(UnturnedPlayer player)
        {
            if (player.IsAdmin)
            {
                return;
            }
            else if (player.HasPermission(this.Configuration.Instance.PolicePermission))
            {
                if(Policia == 0)
                {
                    return;
                }
                Policia = Policia - 1;
            }


            EffectManager.sendUIEffect(27410, 27410, true, Policia.ToString());
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= OnPlayerConnected;
            U.Events.OnPlayerDisconnected -= OnPlayerDisconnected;
        }

    }
}
