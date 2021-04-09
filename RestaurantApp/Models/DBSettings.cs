﻿using Newtonsoft.Json;
using Restaurant.Core;
using RestaurantApp.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class DbSettings
    {
        public string ServerName { get; set; }
        public string DbName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string Username { get; set; }
        public string CrptyPassword { get; set; }
        public const string CONFIGFOLDER = @"Config\";
        public const string DBSETTINGS = @"Config\DbSettings.json";
        private static DbSettings settings = new DbSettings();

        private DbSettings()
        {
        }

        public static DbSettings Get()
        {
            Directory.CreateDirectory(CONFIGFOLDER);

            if (File.Exists(DBSETTINGS))
            {
                string json = File.ReadAllText(DBSETTINGS);
                settings = JsonConvert.DeserializeObject<DbSettings>(json);
            }
            else
            {
                Helper.Log(new Exception("Server not found    \n"));
                settings = new DbSettings()
                {
                    ServerName = "",
                    DbName = "Online-RestaurantApp",
                    IntegratedSecurity = true
                };

                string json = JsonConvert.SerializeObject(settings);
                File.WriteAllText(DBSETTINGS, json);
            }

            return settings;
        }

        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = settings.ServerName;
            builder.InitialCatalog = settings.DbName;
            builder.IntegratedSecurity = settings.IntegratedSecurity;

            if (!builder.IntegratedSecurity)
            {
                builder.UserID = settings.Username;
                builder.Password = SecurityHelper.Decrypt(settings.CrptyPassword);
            }
            return builder.ConnectionString;
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(DBSETTINGS, json);
        }
    }
}
