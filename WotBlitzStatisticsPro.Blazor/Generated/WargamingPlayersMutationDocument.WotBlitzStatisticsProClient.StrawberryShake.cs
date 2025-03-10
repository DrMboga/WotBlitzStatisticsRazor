﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Represents the operation service of the WargamingPlayers GraphQL operation
    /// <code>
    /// mutation WargamingPlayers {
    ///   removePlayerHistory(realm: RU, accountId: 12345)
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingPlayersMutationDocument : global::StrawberryShake.IDocument
    {
        private WargamingPlayersMutationDocument()
        {
        }

        public static WargamingPlayersMutationDocument Instance { get; } = new WargamingPlayersMutationDocument();
        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Mutation;
        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{0x6d, 0x75, 0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x57, 0x61, 0x72, 0x67, 0x61, 0x6d, 0x69, 0x6e, 0x67, 0x50, 0x6c, 0x61, 0x79, 0x65, 0x72, 0x73, 0x20, 0x7b, 0x20, 0x72, 0x65, 0x6d, 0x6f, 0x76, 0x65, 0x50, 0x6c, 0x61, 0x79, 0x65, 0x72, 0x48, 0x69, 0x73, 0x74, 0x6f, 0x72, 0x79, 0x28, 0x72, 0x65, 0x61, 0x6c, 0x6d, 0x3a, 0x20, 0x52, 0x55, 0x2c, 0x20, 0x61, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x49, 0x64, 0x3a, 0x20, 0x31, 0x32, 0x33, 0x34, 0x35, 0x29, 0x20, 0x7d};
        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("md5Hash", "9e9dc9903157ecf352cf78698ecf670f");
        public override global::System.String ToString()
        {
#if NETSTANDARD2_0
        return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
#else
            return global::System.Text.Encoding.UTF8.GetString(Body);
#endif
        }
    }
}
