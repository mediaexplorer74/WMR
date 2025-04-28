﻿using System.Xml.Serialization;
using craftersmine.SteamGridDBNet;

namespace WMR.Indexing
{
    [XmlRoot("Game")]
    public class Game
    {
        [XmlElement("StoreId")]
        public string StoreId { get; set; }
    }

    /// <summary>Represents a game from EGS</summary>
    public class EGSGameInfo
    {
        public string LaunchExecutable { get; set; }
        public string InstallLocation { get; set; }
        public string DisplayName { get; set; }
        public string CatalogNamespace { get; set; }
        public string CatalogItemId { get; set; }
        public string AppName { get; set; }
    }

    ///<summary>Used for sorting and starting applications</summary>
    [Flags]
    public enum ApplicationKind
    {
        SteamGame = 1,
        EpicGamesGame = 2,
        GOGGame = 4,
        RobloxPlayer = 8,
        XboxGame = 16,
        Launcher = 32,
        LauncherPackaged = 64,
        Packaged = 128,
        Normal = 256
    }

    /// <summary>Represents an item in the start menu</summary>
    public class StartMenuItem
    {
        public string ItemName { get; set; }
        public ApplicationKind ItemKind { get; set; }
        public string ItemStartURI { get; set; }
        public BitmapImage Icon { get; set; }
        public SteamGridDbGame GameInfo { get; set; }
        public string Id { get; set; }
    }

    public static class Extensions
    {
        public static bool IsDuplicate(this StartMenuItem item, ObservableCollection<StartMenuItem> collection)
        {
            foreach (var collectionItem in collection)
            {
                if (collectionItem.ItemKind == item.ItemKind && (collectionItem.Id is null || item.Id is null || collectionItem.Id.Equals(item.Id, StringComparison.InvariantCultureIgnoreCase)) && collectionItem.ItemName.Equals(item.ItemName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
