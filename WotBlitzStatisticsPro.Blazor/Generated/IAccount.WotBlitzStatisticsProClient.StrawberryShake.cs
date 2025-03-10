﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Information about player
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial interface IAccount : IStatistics
    {
        /// <summary>
        /// Player account identifier
        /// </summary>
        public global::System.Int64 AccountId { get; }

        /// <summary>
        /// Account creation date
        /// </summary>
        public global::System.DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Player's nick
        /// </summary>
        public global::System.String? Nickname { get; }

        /// <summary>
        /// Tank id, which kills max frags per battle
        /// </summary>
        public global::System.Int64 MaxFragsTankId { get; }

        /// <summary>
        /// Tank Id which created max experience per battle
        /// </summary>
        public global::System.Int64 MaxXpTankId { get; }

        /// <summary>
        /// Average tier
        /// </summary>
        public global::System.Double AvgTier { get; }

        /// <summary>
        /// Clan info
        /// </summary>
        public global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_ClanInfo? ClanInfo { get; }

        /// <summary>
        /// All player's tanks
        /// </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::WotBlitzStatisticsPro.Blazor.GraphQl.IPlayer_AccountInfo_Tanks>? Tanks { get; }
    }
}
