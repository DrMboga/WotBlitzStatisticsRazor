﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    /// <summary>
    /// Represents the operation service of the UpdatePlayer GraphQL operation
    /// <code>
    /// mutation UpdatePlayer($accountId: Long!, $realmType: RealmType!, $requestLanguage: RequestLanguage!) {
    ///   gatherAccountInformation(accountId: $accountId, realmType: $realmType, requestLanguage: $requestLanguage)
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial interface IUpdatePlayerMutation : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IUpdatePlayerResult>> ExecuteAsync(global::System.Int64 accountId, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType realmType, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage requestLanguage, global::System.Threading.CancellationToken cancellationToken = default);
        global::System.IObservable<global::StrawberryShake.IOperationResult<IUpdatePlayerResult>> Watch(global::System.Int64 accountId, global::WotBlitzStatisticsPro.Blazor.GraphQl.RealmType realmType, global::WotBlitzStatisticsPro.Blazor.GraphQl.RequestLanguage requestLanguage, global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}
