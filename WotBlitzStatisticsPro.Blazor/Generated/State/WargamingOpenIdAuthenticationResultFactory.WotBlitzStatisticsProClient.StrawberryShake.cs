﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingOpenIdAuthenticationResultFactory : global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.WargamingOpenIdAuthenticationResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public WargamingOpenIdAuthenticationResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthenticationResult);
        public WargamingOpenIdAuthenticationResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is WargamingOpenIdAuthenticationResultInfo info)
            {
                return new WargamingOpenIdAuthenticationResult(MapNonNullableIWargamingOpenIdAuthentication_ProlongAuthToken(info.ProlongAuthToken, snapshot));
            }

            throw new global::System.ArgumentException("WargamingOpenIdAuthenticationResultInfo expected.");
        }

        private global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthentication_ProlongAuthToken MapNonNullableIWargamingOpenIdAuthentication_ProlongAuthToken(global::WotBlitzStatisticsPro.Blazor.GraphQl.State.WargamingProlongInfoData data, global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            IWargamingOpenIdAuthentication_ProlongAuthToken returnValue = default !;
            if (data.__typename.Equals("WargamingProlongInfo", global::System.StringComparison.Ordinal))
            {
                returnValue = new WargamingOpenIdAuthentication_ProlongAuthToken_WargamingProlongInfo(data.AccessToken ?? throw new global::System.ArgumentNullException(), data.AccountId ?? throw new global::System.ArgumentNullException(), data.ExpirationTimeStamp ?? throw new global::System.ArgumentNullException());
            }
            else
            {
                throw new global::System.NotSupportedException();
            }

            return returnValue;
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(dataInfo, snapshot);
        }
    }
}
