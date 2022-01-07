﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WRR.Server
{
    enum ProtocolType : short
    {
		//------------------------------------------------------
		// Chatting Server
		//------------------------------------------------------
		en_PACKET_CS_CHAT_SERVER = 0,

		//------------------------------------------------------------
		// 채팅서버 로그인 요청
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//		WCHAR	ID[20]				// null 포함 - 사용하지 않음.
		//		WCHAR	Nickname[20]		// null 포함
		//		char	SessionKey[64];		// 인증토큰 - 무시
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_CHAT_REQ_LOGIN,

		//------------------------------------------------------------
		// 채팅서버 로그인 응답
		//
		//	{
		//		WORD	Type
		//
		//		BYTE	Status				// 0:실패	1:성공
		//		INT64	AccountNo
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_CHAT_RES_LOGIN,

		//------------------------------------------------------------
		// 채팅서버 섹터 이동 요청
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//		WORD	SectorX
		//		WORD	SectorY
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_CHAT_REQ_SECTOR_MOVE,

		//------------------------------------------------------------
		// 채팅서버 섹터 이동 결과
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//		WORD	SectorX
		//		WORD	SectorY
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_CHAT_RES_SECTOR_MOVE,

		//------------------------------------------------------------
		// 채팅서버 채팅보내기 요청
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//		WORD	MessageLen
		//		WCHAR	Message[MessageLen / 2]		// null 미포함
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_CHAT_REQ_MESSAGE,

		//------------------------------------------------------------
		// 채팅서버 채팅보내기 응답  (다른 클라가 보낸 채팅도 이걸로 받음)
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//		WCHAR	ID[20]						// null 포함 - 사용하지 않음.
		//		WCHAR	Nickname[20]				// null 포함
		//		
		//		WORD	MessageLen
		//		WCHAR	Message[MessageLen / 2]		// null 미포함
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_CHAT_RES_MESSAGE,
	}
}
