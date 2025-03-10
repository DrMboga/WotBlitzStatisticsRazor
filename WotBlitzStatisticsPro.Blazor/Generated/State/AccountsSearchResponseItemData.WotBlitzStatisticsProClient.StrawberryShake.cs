﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    ///<summary>Account search result item</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class AccountsSearchResponseItemData
    {
        public AccountsSearchResponseItemData(global::System.String __typename, global::System.Int64? accountId = default !, global::System.String? nickname = default !, global::System.String? clanTag = default !, global::System.DateTimeOffset? lastBattle = default !, global::System.Int64? battlesCount = default !, global::System.Int32? winRate = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            AccountId = accountId;
            Nickname = nickname;
            ClanTag = clanTag;
            LastBattle = lastBattle;
            BattlesCount = battlesCount;
            WinRate = winRate;
        }

        public global::System.String __typename { get; }

        ///<summary>Player accountId</summary>
        public global::System.Int64? AccountId { get; }

        ///<summary>Player nick</summary>
        public global::System.String? Nickname { get; }

        ///<summary>Clan tag. Null if player doesn't have clan membership</summary>
        public global::System.String? ClanTag { get; }

        ///<summary>Last battle time</summary>
        public global::System.DateTimeOffset? LastBattle { get; }

        ///<summary>Player's battles count</summary>
        public global::System.Int64? BattlesCount { get; }

        ///<summary>Win rate from 0 to 100</summary>
        public global::System.Int32? WinRate { get; }
    }
}
