﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Platform_Racing_3_Server.Game.Communication.Messages.Incoming.Json;

namespace Platform_Racing_3_Server.Game.Communication.Messages
{
	[JsonSerializable(typeof(JsonAcceptThingTransferIncomingMessage))]
	[JsonSerializable(typeof(JsonBanFromMatchListingIncomingMessage))]
	[JsonSerializable(typeof(JsonCoinsIncomingMessage))]
	[JsonSerializable(typeof(JsonCreateMatchIncomingMessage))]
	[JsonSerializable(typeof(JsonDashIncomingMessage))]
	[JsonSerializable(typeof(JsonDeletePmsIncomingMessage))]
	[JsonSerializable(typeof(JsonEditUserListIncomingMessage))]
	[JsonSerializable(typeof(JsonGetHatIncomingMessage))]
	[JsonSerializable(typeof(JsonGetLevelListIncomingMessage))]
	[JsonSerializable(typeof(JsonGetMemberListIncomingMessage))]
	[JsonSerializable(typeof(JsonGetPmIncomingMessage))]
	[JsonSerializable(typeof(JsonGetPmsIncomingMessage))]
	[JsonSerializable(typeof(JsonGetUserListIncomingMessage))]
	[JsonSerializable(typeof(JsonGetUserPageIncomingMessage))]
	[JsonSerializable(typeof(JsonJoinRoomIncomingMessage))]
	[JsonSerializable(typeof(JsonKickFromMatchListingIncomingMessage))]
	[JsonSerializable(typeof(JsonKothIncomingMessage))]
	[JsonSerializable(typeof(JsonLeaveRoomIncomingMessage))]
	[JsonSerializable(typeof(JsonLegacyPingIncomingMessage))]
	[JsonSerializable(typeof(JsonLoseHatIncomingMessage))]
	[JsonSerializable(typeof(JsonManageVarsIncomingMessage))]
	[JsonSerializable(typeof(JsonRateLevelIncomingMessage))]
	[JsonSerializable(typeof(JsonReportPmIncomingMessage))]
	[JsonSerializable(typeof(JsonRequestMatchesIncomingMessage))]
	[JsonSerializable(typeof(JsonSendPmIncomingMessage))]
	[JsonSerializable(typeof(JsonSendThingIncomingMessage))]
	[JsonSerializable(typeof(JsonSendToRoomIncomingMessage))]
	[JsonSerializable(typeof(JsonSetAccountSettingsMessage))]
	[JsonSerializable(typeof(JsonThingExistsIncomingMessage))]
	[JsonSerializable(typeof(JsonTokenLoginIncomingMessage))]
	[JsonSerializable(typeof(JsonWinHatIncomingMessage))]
	[JsonSerializable(typeof(JsonConfirmConnectionIncomingMessage))]
	[JsonSerializable(typeof(JsonGuestLoginIncomingPacket))]
	[JsonSerializable(typeof(JsonGetLevelOfTheDayIncomingMessage))]
	[JsonSerializable(typeof(JsonGetTournamentIncomingMessage))]
	[JsonSerializable(typeof(JsonGetRoomsIncomingMessage))]
	[JsonSerializable(typeof(JsonLeaveLobbyIncomingMessage))]
	[JsonSerializable(typeof(JsonForceStartIncomingMessage))]
	[JsonSerializable(typeof(JsonFinishDrawingIncomingMessage))]
	[JsonSerializable(typeof(JsonForfietIncomingMessage))]
	[JsonSerializable(typeof(JsonFinishMatchIncomingMessage))]
	[JsonSerializable(typeof(JsonStartQucikJoinIncomingMessage))]
	[JsonSerializable(typeof(JsonStopQuickJoinIncomingMessage))]
	[JsonSerializable(typeof(JsonJoinTournamentIncomingMessage))]
	internal sealed partial class JsonIncomingPacketContext : JsonSerializerContext
	{
	}
}
