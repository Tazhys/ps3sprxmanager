using System;
using System.Collections.Generic;

namespace EbootExpress
{
    internal sealed class GameRegionPreset
    {
        internal GameRegionPreset(string game, string code, string titleId)
        {
            Game = game;
            Code = code;
            TitleId = titleId;
            DisplayText = string.Equals(code, titleId, StringComparison.Ordinal)
                ? code
                : code + " (folder: " + titleId + ")";
        }

        public string Game { get; private set; }
        public string Code { get; private set; }
        public string TitleId { get; private set; }
        public string DisplayText { get; private set; }
    }

    internal static class GameRegionCatalog
    {
        private static readonly string[] GameNames = { "MW2", "MW3", "BO2" };
        private static readonly Dictionary<string, List<GameRegionPreset>> PresetsByGame = BuildPresets();
        private static readonly IList<GameRegionPreset> EmptyPresetList =
            Array.AsReadOnly(new GameRegionPreset[0]);

        internal static string[] Games
        {
            get { return (string[])GameNames.Clone(); }
        }

        internal static IList<GameRegionPreset> GetPresetsForGame(string game)
        {
            List<GameRegionPreset> presets;
            return PresetsByGame.TryGetValue(game ?? string.Empty, out presets)
                ? presets.AsReadOnly()
                : EmptyPresetList;
        }

        internal static IList<GameRegionPreset> FindInstalledPresets(IEnumerable<string> directoryEntries)
        {
            if (directoryEntries == null)
            {
                throw new ArgumentNullException("directoryEntries");
            }

            HashSet<string> installedTitleIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string entry in directoryEntries)
            {
                string titleId = GetDirectoryEntryName(entry);
                if (!string.IsNullOrEmpty(titleId))
                {
                    installedTitleIds.Add(titleId);
                }
            }

            List<GameRegionPreset> matches = new List<GameRegionPreset>();
            foreach (string game in GameNames)
            {
                List<GameRegionPreset> presets = PresetsByGame[game];
                HashSet<string> matchedTitleIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (GameRegionPreset preset in presets)
                {
                    if (!installedTitleIds.Contains(preset.TitleId)
                        || !matchedTitleIds.Add(preset.TitleId))
                    {
                        continue;
                    }

                    GameRegionPreset titlePreset = presets.Find(candidate =>
                        string.Equals(candidate.TitleId, preset.TitleId, StringComparison.OrdinalIgnoreCase)
                        && string.Equals(candidate.Code, candidate.TitleId, StringComparison.OrdinalIgnoreCase));
                    matches.Add(titlePreset ?? preset);
                }
            }

            return matches.AsReadOnly();
        }

        private static string GetDirectoryEntryName(string entry)
        {
            if (string.IsNullOrWhiteSpace(entry))
            {
                return string.Empty;
            }

            string normalized = entry.Trim().Replace('\\', '/').TrimEnd('/');
            int separator = normalized.LastIndexOf('/');
            string name = separator >= 0 ? normalized.Substring(separator + 1) : normalized;
            return name == "." || name == ".." ? string.Empty : name;
        }

        private static Dictionary<string, List<GameRegionPreset>> BuildPresets()
        {
            Dictionary<string, List<GameRegionPreset>> presetsByGame =
                new Dictionary<string, List<GameRegionPreset>>(StringComparer.Ordinal);

            AddGame(presetsByGame, "MW2", new[]
            {
                "NPUB30585",
                "NPUB30586",
                "BLUS30429",
                "NPEB00731",
                "BLES00683",
                "NPEB00732",
                "BLES00684",
                "NPEB00733",
                "BLES00685",
                "NPEB00734",
                "BLES00686",
                "NPEB00735",
                "BLES00687"
            });

            AddGame(presetsByGame, "MW3", new[]
            {
                "NPUB30787",
                "BLUS30838",
                "NPUB30788",
                "BLUS30887",
                "NPEB00964",
                "BLES01428",
                "NPEB00965",
                "BLES01429",
                "NPEB00966",
                "BLES01430",
                "NPEB00967",
                "BLES01431",
                "NPEB00968",
                "BLES01432",
                "NPEB00977",
                "BLES01433",
                "NPEB00978",
                "BLES01434"
            });

            AddGame(presetsByGame, "BO2", new[]
            {
                "TEST00000",
                "UP0002-BLUS31011_00",
                "UP0002-NPUB30607_00",
                "NPUB30607",
                "BLUS31011",
                "BLES01717",
                "EP0002-BLES01717_00",
                "EP0002-NPEB00785_00",
                "NPEB00801",
                "BLES01718",
                "EP0002-BLES01718_00",
                "BLES01719",
                "EP0002-BLES01719_00",
                "BLES01720",
                "EP0002-BLES01720_00",
                "BLUS31141",
                "UP0002-BLUS31141_00",
                "BLUS31140",
                "UP0002-BLUS31140_00",
                "BLJM60548",
                "JP0082-BLJM60548_00",
                "BLJM60549",
                "JP0082-BLJM60549_00",
                "NPUB31054",
                "NPUB31056",
                "NPUB31055",
                "NPEB01205",
                "NPEB01206",
                "NPEB01207",
                "NPEB01204"
            });

            return presetsByGame;
        }

        private static void AddGame(
            IDictionary<string, List<GameRegionPreset>> presetsByGame,
            string game,
            IEnumerable<string> codes)
        {
            List<GameRegionPreset> gamePresets = new List<GameRegionPreset>();
            foreach (string code in codes)
            {
                gamePresets.Add(new GameRegionPreset(game, code, GetTitleId(code)));
            }

            presetsByGame.Add(game, gamePresets);
        }

        private static string GetTitleId(string code)
        {
            if (IsTitleId(code))
            {
                return code;
            }

            int separator = code.IndexOf('-');
            if (separator != 6 || code.IndexOf('-', separator + 1) >= 0)
            {
                throw new InvalidOperationException("Unrecognized game or package code: " + code);
            }

            string publisherCode = code.Substring(0, separator);
            if (!IsPublisherCode(publisherCode))
            {
                throw new InvalidOperationException("Unrecognized package publisher code: " + code);
            }

            string packageTitle = code.Substring(separator + 1);
            if (packageTitle.Length != 12 || packageTitle[9] != '_'
                || !string.Equals(packageTitle.Substring(10), "00", StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Unrecognized package title code: " + code);
            }

            string titleId = packageTitle.Substring(0, 9);
            if (!IsTitleId(titleId))
            {
                throw new InvalidOperationException("Unrecognized package title ID: " + code);
            }

            return titleId;
        }

        private static bool IsTitleId(string value)
        {
            if (value == null || value.Length != 9)
            {
                return false;
            }

            for (int index = 0; index < 4; index++)
            {
                if (value[index] < 'A' || value[index] > 'Z')
                {
                    return false;
                }
            }

            for (int index = 4; index < value.Length; index++)
            {
                if (value[index] < '0' || value[index] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPublisherCode(string value)
        {
            if (value == null || value.Length != 6
                || value[0] < 'A' || value[0] > 'Z'
                || value[1] < 'A' || value[1] > 'Z')
            {
                return false;
            }

            for (int index = 2; index < value.Length; index++)
            {
                if (value[index] < '0' || value[index] > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
