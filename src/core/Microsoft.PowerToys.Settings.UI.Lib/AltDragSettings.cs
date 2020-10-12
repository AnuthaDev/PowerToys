﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.PowerToys.Settings.UI.Lib.Interface;

namespace Microsoft.PowerToys.Settings.UI.Lib
{
    public class AltDragSettings : BasePTModuleSettings, ISettingsConfig
    {
        public const string ModuleName = "AltDrag";

        [JsonPropertyName("properties")]
        public AltDragProperties Properties { get; set; }

        public AltDragSettings()
        {
            Properties = new AltDragProperties();
            Version = "1";
            Name = ModuleName;
        }

        public virtual void Save(ISettingsUtils settingsUtils)
        {
            // Save settings to file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            settingsUtils.SaveSettings(JsonSerializer.Serialize(this, options), ModuleName);
        }

        public string GetModuleName()
        {
            return Name;
        }

        // This can be utilized in the future if the settings.json file is to be modified/deleted.
        public bool UpgradeSettingsConfiguration()
        {
            return false;
        }
    }
}
