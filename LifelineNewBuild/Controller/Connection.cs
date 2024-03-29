﻿using Npgsql;
using System;

namespace LifelineNewBuild.Controller
{
    internal class Connection
    {
        public (NpgsqlConnection, NpgsqlCommand) InitializeConnection()
        {
            NpgsqlConnection con;
            NpgsqlCommand cmd;

            var uriString = "postgres://szhlblek:O4cczwKuCRX3ta_f_n4K8KjTvvfeSFZW@satao.db.elephantsql.com/szhlblek";
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);

            con = new NpgsqlConnection(connStr);
            cmd = new NpgsqlCommand();

            return (con, cmd);
        }
    }
}
