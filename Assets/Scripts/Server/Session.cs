using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace WRR.Server
{
    public class Session
    {
        private Int32 _dataBufferSize = 4096;
        private IPAddress _ipAddress;
        private Int32 _port;
        public Int64 _uniqueID;
        static private TcpClient _socket;
        static private NetworkStream _stream;
        private byte[] _recieveBuffer;
        private Packet _receiveData;

        public delegate void PacketHandler(Packet aPacket);

        public Dictionary<Int32, PacketHandler> _packetHandlers = new Dictionary<Int32, PacketHandler>();
        public ConcurrentQueue<Packet> _recvQueue = new ConcurrentQueue<Packet>();

        public bool DnsInit(Int32 port)
        {
            IPHostEntry ipEntry = Dns.GetHostEntry("richard0326.iptime.org");

            try
            {
                _ipAddress = ipEntry.AddressList[0];

                Debug.Log("Dns IP : " + _ipAddress.ToString());
            }
            catch (Exception e)
            {
                Debug.Log("DnsInit Fail : " + e.ToString());
            }

            return true;
        }

        public bool IpInit(string ipStr, Int32 port)
        {
            try
            {
                _ipAddress = IPAddress.Parse(ipStr);
                _port = port;

                Debug.Log("IP : " + _ipAddress.ToString() + "Port : " + _port);
            }
            catch (Exception e)
            {
                Debug.Log("IpInit Fail : " + e.ToString());
            }

            return true;
        }

        public bool Connect()
        {
            if (_socket != null)
            {
                Debug.Log("Already Tried Connection");
                return false;
            }

            _socket = new TcpClient();

            _recieveBuffer = new byte[_dataBufferSize];

            try
            {
                _socket.BeginConnect(_ipAddress, _port, ConnectCallBack, this);
            }
            catch (SocketException e)
            {
                Debug.Log("Connect Fail : " + e.ToString());
                Disconnect();
                return false;
            }

            return true;
        }

        private void ConnectCallBack(IAsyncResult aResult)
        {
            var resultAsyncState = aResult.AsyncState;
            _socket.EndConnect(aResult);

            if (_socket.Connected == false)
            {
                return;
            }

            _stream = _socket.GetStream();
            _receiveData = new Packet();
            _stream.BeginRead(_recieveBuffer, 0, _dataBufferSize, OnReceive, resultAsyncState);
        }

        public bool SendData(Packet aPacket)
        {
            try
            {
                if (_socket != null)
                {
                    var a = aPacket.ToArray();
                    var len = aPacket.Length();
                    _stream.BeginWrite(a, 0, len, null, null);
                }
            }
            catch (Exception aEX)
            {
                // Debug.LogError("## ERROR(" + _uniqueID + ") : " + aEX.ToString());
                Disconnect();
                return false;
            }

            return true;
        }

        public void SetPacketHandler(Int32 type, PacketHandler packetHandler)
        {
            _packetHandlers[type] = packetHandler;
        }


        private void OnReceive(IAsyncResult aResult)
        {
            try
            {
                var resultAsyncState = aResult.AsyncState;
                int lByteLength = _stream.EndRead(aResult);

                if (lByteLength <= 0)
                {
                    Disconnect();
                    return;
                }

                byte[] lData = new byte[lByteLength];
                Array.Copy(_recieveBuffer, lData, lByteLength);
                _receiveData.Reset(HandleData(lData));
                _stream.BeginRead(_recieveBuffer, 0, _dataBufferSize, OnReceive, resultAsyncState);
            }
            catch (Exception e)
            {
                Debug.Log("OnReceive Error : " + e.ToString());
                Disconnect();
            }
        }

        public void Disconnect()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket = null;
            }
        }
        
        public void SetUniqueId(Int64 uniqueId)
        {
            _uniqueID = uniqueId;
        }

        private bool HandleData(byte[] aData)
        {
            short packetLength = 0;

            _receiveData.SetBytes(aData);

            if (_receiveData.UnreadLength() >= 2) //int : 2
            {
                packetLength = _receiveData.ReadShort();

                if (packetLength <= 0)
                {
                    return true;
                }
            }

            while (packetLength > 0 && packetLength <= _receiveData.UnreadLength())
            {
                byte[] lPacketBytes = _receiveData.ReadBytes(packetLength);

                _recvQueue.Enqueue(new Packet(lPacketBytes));

                _receiveData.MoveReadPos(packetLength);

                packetLength = 0;

                if (_receiveData.UnreadLength() >= 2)
                {
                    packetLength = _receiveData.ReadShort();

                    if (packetLength <= 0)
                    {
                        return true;
                    }
                }
            }

            if (packetLength <= 1)
            {
                return true;
            }

            return false;
        }
    }
}
