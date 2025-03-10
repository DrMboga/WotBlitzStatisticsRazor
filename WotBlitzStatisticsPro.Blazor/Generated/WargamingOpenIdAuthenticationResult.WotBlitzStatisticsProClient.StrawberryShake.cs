﻿// <auto-generated/>
#nullable enable

namespace WotBlitzStatisticsPro.Blazor.GraphQl
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.12.1.0")]
    public partial class WargamingOpenIdAuthenticationResult : global::System.IEquatable<WargamingOpenIdAuthenticationResult>, IWargamingOpenIdAuthenticationResult
    {
        public WargamingOpenIdAuthenticationResult(global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthentication_ProlongAuthToken prolongAuthToken)
        {
            ProlongAuthToken = prolongAuthToken;
        }

        /// <summary>
        /// Prolongates Wargaming authentication token
        /// </summary>
        public global::WotBlitzStatisticsPro.Blazor.GraphQl.IWargamingOpenIdAuthentication_ProlongAuthToken ProlongAuthToken { get; }

        public virtual global::System.Boolean Equals(WargamingOpenIdAuthenticationResult? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (ProlongAuthToken.Equals(other.ProlongAuthToken));
        }

        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((WargamingOpenIdAuthenticationResult)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash ^= 397 * ProlongAuthToken.GetHashCode();
                return hash;
            }
        }
    }
}
