﻿namespace ResourceHubLauncher {
    class _G {
        public static bool dev => (bool)Config.Options["devmd"];
        public static bool update => (bool)Config.Options["autoUpdate"];

        public static bool beta => (bool)Config.Options["beta"];
    }
}
