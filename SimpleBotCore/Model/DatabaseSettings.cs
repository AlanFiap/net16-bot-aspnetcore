﻿using SimpleBotCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Model
{
    public class DatabaseSettings : IDatabaseSettings
    {

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
