﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingAuthenticationQueryResultFactory : global::StrawberryShake.IOperationResultDataFactory<global::WotBlitzStatisticsPro.Blazor.GraphQl.WargamingAuthenticationQueryResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public WargamingAuthenticationQueryResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingAuthenticationQueryResult);
        public WargamingAuthenticationQueryResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is WargamingAuthenticationQueryResultInfo info)
            {
                return new WargamingAuthenticationQueryResult(info.LoginUrl);
            }

            throw new global::System.ArgumentException("WargamingAuthenticationQueryResultInfo expected.");
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(dataInfo, snapshot);
        }
    }
}
