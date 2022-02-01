using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WRR.Server
{
    class RecvProtocol
    {
        public static void RecvPacketChatResLogin(Packet aPacket, out bool status, out Int64 accountNo)
        {
            status = aPacket.ReadBool();         // 0:실패	1:성공
            accountNo = aPacket.ReadLong();     // 계정 번호
        }

        public static void RecvPacketChatResSectorMove(Packet aPacket, out Int64 accountNo, out short sectorX, out short sectorY)
        {
            accountNo = aPacket.ReadLong();     // 계정 번호
            sectorX = aPacket.ReadShort();     // 계정 번호
            sectorY = aPacket.ReadShort();     // 계정 번호
        }

        public static void RecvPacketChatResMessage(Packet aPacket, out Int64 accountNo, out string id, out string nickname, out string message)
        {
            accountNo = aPacket.ReadLong();             // 계정 번호
            id = aPacket.ReadUnicodeString(40);         // id
            nickname = aPacket.ReadUnicodeString(40);   // nickname

            var messageLen = aPacket.ReadShort();           // 메시지 길이
            message = aPacket.ReadUnicodeString(messageLen); // 메시지
        }

        public static void RecvPacketGameResLogin(Packet aPacket, out bool status, out Int64 accountNo)
        {
            status = aPacket.ReadBool();         // 0:실패	1:성공
            accountNo = aPacket.ReadLong();     // 계정 번호
        }

        public static void RecvPacketGameResSectorMove(Packet aPacket, out Int64 accountNo, out short sectorX, out short sectorY)
        {
            accountNo = aPacket.ReadLong();     // 계정 번호
            sectorX = aPacket.ReadShort();     // 계정 번호
            sectorY = aPacket.ReadShort();     // 계정 번호
        }

        public static void RecvPacketGameResLocationInfo(Packet aPacket, out Int64 accountNo, out double posX, out double posY, out double posZ, out double rotY)
        {
            accountNo = aPacket.ReadLong();     // 계정 번호
            posX = aPacket.ReadDouble();
            posY = aPacket.ReadDouble();
            posZ = aPacket.ReadDouble();
            rotY = aPacket.ReadDouble();
        }
    }
}
