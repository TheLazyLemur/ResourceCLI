﻿using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ResourceCLI.Commands;
using ResourceCLI.Settings;

// DI, Serilog, Settings

namespace ResourceCLI
{
    public class AppInstance
    {
        private readonly ILogger<AppInstance> _log;
        private readonly IConfiguration       _config;
        private readonly List                 _listCmd;
        private readonly Create               _createCmd;
        private readonly Remove               _removeCmd;
        private readonly RemoveOne            _removeOne;

        public AppInstance(
            ILogger<AppInstance> log,
            IConfiguration config,
            List listCmd,
            Remove removeCmd,
            RemoveOne removeOne,
            Create createCmd
        )
        {
            _log = log;
            _config = config;
            _listCmd = listCmd;
            _createCmd = createCmd;
            _removeCmd = removeCmd;
            _removeOne = removeOne;
        }

        public void Run(string[] args)
        {
            if (args.Contains("--dbpath"))
            {
                var dir = Array.IndexOf(args, "--dbpath") + 1;
                Console.WriteLine(args[dir]);
                AppSettings.ConnectionString = args[dir];
            }
            
            if (args.Contains("--list"))
            {
                _log.Log(LogLevel.Information, "Listing all entries");
                _listCmd.RunCmd(args);
            }

            if (args.Contains("--create"))
            {
                _log.Log(LogLevel.Information, "Attempting to create a new entry");
                _createCmd.RunCmd(args);
            }

            if (args.Contains("--delete-all"))
            {
                _log.Log(LogLevel.Information, "Attempting to clear all existing entries");
                _removeCmd.RunCmd(args);
            }

            if (args.Contains("--delete-one"))
            {
                _log.Log(LogLevel.Information, "Attempting to delete a single entry");
                _removeOne.RunCmd(args);
            }
        }
    }
}