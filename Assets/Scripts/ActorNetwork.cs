using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WRR.Server
{
    public class ActorNetwork : MonoBehaviour
    {
        private Session _session;

        bool _isConnected = true;
        bool _callOnce = true;

        void Start()
        {
            if (Init() == false)
            {
                _isConnected = false;
                return;
            }
        }

        private void Update()
        {
            if (_callOnce)
            {
                // Start에서 보내면 문제가 네트워크 초기화 전에 접근해서 문제가 발생할 수 있음.
                SendOnce();
                _callOnce = false;
            }

            RecvLoop();
        }

        private void OnApplicationQuit()
        {
            Release();
        }
        
        public bool Init()
        {
            _session = new Session();
            _session.IpInit("127.0.0.1", 6000);
            //_session.DnsInit(6000);

            if (_session.Connect() == false)
            {
                return false;
            }

            return true;
        }

        public void Release()
        {
            _session.Disconnect();
        }

        public void SendOnce()
        {
            if (SendProtocol.SendPacketReqLogin(_session, 0, "myID", "myNickname", "sessionKey") == false)
            {

            }
        }

        public void RecvLoop()
        {
            Packet outPacket;
            if (_session._recvQueue.TryDequeue(out outPacket) == true)
            {
                short type = outPacket.ReadShort();
                switch ((ProtocolType) type)
                {
                    case ProtocolType.en_PACKET_CS_CHAT_RES_LOGIN:
                    {
                        bool status = false;
                        Int64 accountNo;
                        RecvProtocol.RecvPacketResLogin(outPacket, out status, out accountNo);

                        // 읽은 다음에 할 행동
                        if (status == true)
                        {
                            _session._uniqueID = accountNo;

                            var rand = new System.Random();
                            var x = 0;//rand.Next(0, 50); // 0~49
                            var y = 0;//rand.Next(0, 50); // 0~49
                            // 영역 지정 안해주면, 현재 서버에서는 로그인이 완료되지 못함.
                            SendProtocol.SendPacketReqMove(_session, accountNo, (short) x, (short) y);
                        }
                        //
                    }
                        break;
                    case ProtocolType.en_PACKET_CS_CHAT_RES_SECTOR_MOVE:
                    {
                        Int64 accountNo;
                        short sectorX;
                        short sectorY;
                        RecvProtocol.RecvPacketResMove(outPacket, out accountNo, out sectorX, out sectorY);

                        Debug.Log($" 캐릭터 섹터 위치 : " + sectorX + ", " + sectorY);
                    }
                        break;
                    case ProtocolType.en_PACKET_CS_CHAT_RES_MESSAGE:
                    {
                        Int64 accountNo;
                        string id;
                        string nickname;
                        string message;
                        RecvProtocol.RecvPacketResMessage(outPacket, out accountNo, out id, out nickname, out message);

                        // 읽은 다음에 할 행동
                        ActorCallBackEvent.ChatCallBackEvent?.Invoke(nickname, message);
                        //
                    }
                        break;
                }
            }
        }

        public void SetUniqueId(Int64 uniqueId)
        {
            _session._uniqueID = uniqueId;
        }

        public Session GetSession()
        {
            return _session;
        }
    }
}
