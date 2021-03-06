using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRR.Server
{
    public class SendProtocol
    {
        public static bool SendPacketChatReqLogin(Session session, Int64 AccountNo, string id, string nickname, string SessionKey)
        {
            // type 2 바이트
            using (Packet sendPacket = new Packet((short)ProtocolType.en_PACKET_CS_CHAT_REQ_LOGIN))
            {
                sendPacket.Write(AccountNo);                // 8 바이트
                sendPacket.WriteUnicodeStringFixedSize(id, 40);          // 40 바이트
                sendPacket.WriteUnicodeStringFixedSize(nickname, 40);    // 40 바이트
                sendPacket.WriteAsciiStringFixedSize(SessionKey, 64);  // 64 바이트

                sendPacket.InsertHeader(154);

                session.SendData(sendPacket);
            }

            return true;
        }

        public static bool SendPacketChatReqSectorMove(Session session, Int64 AccountNo, short sectorX, short sectorY)
        {
            // type 2 바이트
            using (Packet sendPacket = new Packet((short)ProtocolType.en_PACKET_CS_CHAT_REQ_SECTOR_MOVE))
            {
                sendPacket.Write(AccountNo);                // 8 바이트
                sendPacket.Write(sectorX);               // 2 바이트
                sendPacket.Write(sectorY);               // 2 바이트

                sendPacket.InsertHeader(14);
                session.SendData(sendPacket);
            }

            return true;
        }

        public static bool SendPacketChatReqMessage(Session session, Int64 AccountNo, short messageLen, string message)
        {
            // type 2 바이트
            using (Packet sendPacket = new Packet((short)ProtocolType.en_PACKET_CS_CHAT_REQ_MESSAGE))
            {
                sendPacket.Write(AccountNo);                // 8 바이트
                sendPacket.Write((short)(messageLen * 2));               // 2 바이트
                sendPacket.WriteUnicodeString(message);     // 실제 메시지의 크기 바이트

                sendPacket.InsertHeader((short)(12 + (int)messageLen * 2));

                session.SendData(sendPacket);
            }

            return true;
        }

        public static bool SendPacketGameReqLogin(Session session, Int64 AccountNo)
        {
            // type 2 바이트
            using (Packet sendPacket = new Packet((short)ProtocolType.en_PACKET_CS_GAME_REQ_LOGIN))
            {
                sendPacket.Write(AccountNo);                // 8 바이트

                sendPacket.InsertHeader(10);

                session.SendData(sendPacket);
            }

            return true;
        }

        public static bool SendPacketGameReqSectorMove(Session session, Int64 AccountNo, short sectorX, short sectorY)
        {
            // type 2 바이트
            using (Packet sendPacket = new Packet((short)ProtocolType.en_PACKET_CS_GAME_REQ_SECTOR_MOVE))
            {
                sendPacket.Write(AccountNo);                // 8 바이트
                sendPacket.Write(sectorX);               // 2 바이트
                sendPacket.Write(sectorY);               // 2 바이트

                sendPacket.InsertHeader(14);
                session.SendData(sendPacket);
            }

            return true;
        }

        public static bool SendPacketGameReqLocationInfo(Session session, Int64 AccountNo, double posX, double posY, double posZ, double rotY)
        {
            // type 2 바이트
            using (Packet sendPacket = new Packet((short)ProtocolType.en_PACKET_CS_GAME_REQ_LOCATION_INFO))
            {
                sendPacket.Write(AccountNo);                // 8 바이트
                sendPacket.Write(posX);               // 8 바이트
                sendPacket.Write(posY);               // 8 바이트
                sendPacket.Write(posZ);               // 8 바이트
                sendPacket.Write(rotY);               // 8 바이트

                sendPacket.InsertHeader(42);
                session.SendData(sendPacket);
            }

            return true;
        }
    }
}
