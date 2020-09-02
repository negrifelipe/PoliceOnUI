using Rocket.API;

namespace F.PoliceOnUI
{
    public class Config : IRocketPluginConfiguration
    {
        public string PolicePermission;

        public void LoadDefaults()
        {
            PolicePermission = "Police";
        }
    }
}
