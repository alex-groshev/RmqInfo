﻿using System;

namespace Domain.Model
{
    public class RmqConnection
    {
        public string Name
        {
            get
            {
                return _name ?? (_name = string.Format("[{0}]:{1} -> [{2}]:{3}", _peerHost, _peerPort, _host, _port));
            }
        }

        public string User
        {
            get { return _user; }
        }

        public string ConnectedAt
        {
            get { return _rmqConnectionStatus.ConnectedAt.ToString(); }
        }

        public string State
        {
            get { return _rmqConnectionStatus.State; }
        }

        public RmqConnection(string user, string host, int port, string peerHost, int peerPort, RmqConnectionStatus rmqConnectionStatus)
        {
            if (string.IsNullOrEmpty(user))
                throw new ArgumentException("user");

            _user = user;

            if (string.IsNullOrEmpty(host))
                throw new ArgumentException("host");

            _host = host;
            _port = port;

            if (string.IsNullOrEmpty(peerHost))
                throw new ArgumentException("peerHost");

            _peerHost = peerHost;
            _peerPort = peerPort;
            _rmqConnectionStatus = rmqConnectionStatus;
        }

        public override string ToString()
        {
            return Name;
        }

        private readonly string _user;
        private readonly string _host;
        private readonly int _port;
        private readonly string _peerHost;
        private readonly int _peerPort;
        private string _name;
        private readonly RmqConnectionStatus _rmqConnectionStatus;
    }
}
