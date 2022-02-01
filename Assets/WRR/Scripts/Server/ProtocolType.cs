using System;
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

		//------------------------------------------------------
		// Game Server
		//------------------------------------------------------
		en_PACKET_CS_GAME_SERVER = 1000,

		//------------------------------------------------------------
		// 로그인 요청
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_GAME_REQ_LOGIN,

		//------------------------------------------------------------
		// 로그인 응답
		//
		//	{
		//		WORD	Type
		//
		//		BYTE	Status (0: 실패 / 1: 성공)
		//		INT64	AccountNo
		//	}
		//
		//	지금 더미는 무조건 성공으로 판단하고 있음
		//	Status 결과를 무시한다는 이야기
		//
		//  en_PACKET_CS_GAME_RES_LOGIN define 값 사용.
		//------------------------------------------------------------
		en_PACKET_CS_GAME_RES_LOGIN,

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
		en_PACKET_CS_GAME_REQ_SECTOR_MOVE,

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
		en_PACKET_CS_GAME_RES_SECTOR_MOVE,

		//------------------------------------------------------------
		// 이동 요청
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//		DOUBLE	PosX
		//		DOUBLE	PosY
		//		DOUBLE	PosZ
		//		DOUBLE	RotY
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_GAME_REQ_LOCATION_INFO,

		//------------------------------------------------------------
		// 이동 응답
		//
		//	{
		//		WORD	Type
		//
		//		INT64	AccountNo
		//		DOUBLE	PosX
		//		DOUBLE	PosY
		//		DOUBLE	PosZ
		//		DOUBLE	RotY
		//	}
		//
		//------------------------------------------------------------
		en_PACKET_CS_GAME_RES_LOCATION_INFO,
	}
}
