﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViesVat
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat", ConfigurationName="ViesVat.checkVatPortType")]
    public interface checkVatPortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ViesVat.checkVatResponse checkVat(ViesVat.checkVatRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<ViesVat.checkVatResponse> checkVatAsync(ViesVat.checkVatRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ViesVat.checkVatApproxResponse checkVatApprox(ViesVat.checkVatApproxRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<ViesVat.checkVatApproxResponse> checkVatApproxAsync(ViesVat.checkVatApproxRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVat", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        public checkVatRequest()
        {
        }
        
        public checkVatRequest(string countryCode, string vatNumber)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVatResponse", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime requestDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=3)]
        public bool valid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string address;
        
        public checkVatResponse()
        {
        }
        
        public checkVatResponse(string countryCode, string vatNumber, System.DateTime requestDate, bool valid, string name, string address)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
            this.requestDate = requestDate;
            this.valid = valid;
            this.name = name;
            this.address = address;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types")]
    public enum matchCode
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVatApprox", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatApproxRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=2)]
        public string traderName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=3)]
        public string traderCompanyType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=4)]
        public string traderStreet;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=5)]
        public string traderPostcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=6)]
        public string traderCity;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=7)]
        public string requesterCountryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=8)]
        public string requesterVatNumber;
        
        public checkVatApproxRequest()
        {
        }
        
        public checkVatApproxRequest(string countryCode, string vatNumber, string traderName, string traderCompanyType, string traderStreet, string traderPostcode, string traderCity, string requesterCountryCode, string requesterVatNumber)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
            this.traderName = traderName;
            this.traderCompanyType = traderCompanyType;
            this.traderStreet = traderStreet;
            this.traderPostcode = traderPostcode;
            this.traderCity = traderCity;
            this.requesterCountryCode = requesterCountryCode;
            this.requesterVatNumber = requesterVatNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="checkVatApproxResponse", WrapperNamespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", IsWrapped=true)]
    public partial class checkVatApproxResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=0)]
        public string countryCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=1)]
        public string vatNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime requestDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=3)]
        public bool valid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string traderName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string traderCompanyType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=6)]
        public string traderAddress;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=7)]
        public string traderStreet;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=8)]
        public string traderPostcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=9)]
        public string traderCity;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=10)]
        public ViesVat.matchCode traderNameMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=11)]
        public ViesVat.matchCode traderCompanyTypeMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=12)]
        public ViesVat.matchCode traderStreetMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=13)]
        public ViesVat.matchCode traderPostcodeMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=14)]
        public ViesVat.matchCode traderCityMatch;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:ec.europa.eu:taxud:vies:services:checkVat:types", Order=15)]
        public string requestIdentifier;
        
        public checkVatApproxResponse()
        {
        }
        
        public checkVatApproxResponse(
                    string countryCode, 
                    string vatNumber, 
                    System.DateTime requestDate, 
                    bool valid, 
                    string traderName, 
                    string traderCompanyType, 
                    string traderAddress, 
                    string traderStreet, 
                    string traderPostcode, 
                    string traderCity, 
                    ViesVat.matchCode traderNameMatch, 
                    ViesVat.matchCode traderCompanyTypeMatch, 
                    ViesVat.matchCode traderStreetMatch, 
                    ViesVat.matchCode traderPostcodeMatch, 
                    ViesVat.matchCode traderCityMatch, 
                    string requestIdentifier)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
            this.requestDate = requestDate;
            this.valid = valid;
            this.traderName = traderName;
            this.traderCompanyType = traderCompanyType;
            this.traderAddress = traderAddress;
            this.traderStreet = traderStreet;
            this.traderPostcode = traderPostcode;
            this.traderCity = traderCity;
            this.traderNameMatch = traderNameMatch;
            this.traderCompanyTypeMatch = traderCompanyTypeMatch;
            this.traderStreetMatch = traderStreetMatch;
            this.traderPostcodeMatch = traderPostcodeMatch;
            this.traderCityMatch = traderCityMatch;
            this.requestIdentifier = requestIdentifier;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface checkVatPortTypeChannel : ViesVat.checkVatPortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class checkVatPortTypeClient : System.ServiceModel.ClientBase<ViesVat.checkVatPortType>, ViesVat.checkVatPortType
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public checkVatPortTypeClient() : 
                base(checkVatPortTypeClient.GetDefaultBinding(), checkVatPortTypeClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.checkVatPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(EndpointConfiguration endpointConfiguration) : 
                base(checkVatPortTypeClient.GetBindingForEndpoint(endpointConfiguration), checkVatPortTypeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(checkVatPortTypeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(checkVatPortTypeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public checkVatPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ViesVat.checkVatResponse ViesVat.checkVatPortType.checkVat(ViesVat.checkVatRequest request)
        {
            return base.Channel.checkVat(request);
        }
        
        public System.DateTime checkVat(ref string countryCode, ref string vatNumber, out bool valid, out string name, out string address)
        {
            ViesVat.checkVatRequest inValue = new ViesVat.checkVatRequest();
            inValue.countryCode = countryCode;
            inValue.vatNumber = vatNumber;
            ViesVat.checkVatResponse retVal = ((ViesVat.checkVatPortType)(this)).checkVat(inValue);
            countryCode = retVal.countryCode;
            vatNumber = retVal.vatNumber;
            valid = retVal.valid;
            name = retVal.name;
            address = retVal.address;
            return retVal.requestDate;
        }
        
        public System.Threading.Tasks.Task<ViesVat.checkVatResponse> checkVatAsync(ViesVat.checkVatRequest request)
        {
            return base.Channel.checkVatAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ViesVat.checkVatApproxResponse ViesVat.checkVatPortType.checkVatApprox(ViesVat.checkVatApproxRequest request)
        {
            return base.Channel.checkVatApprox(request);
        }
        
        public System.DateTime checkVatApprox(
                    ref string countryCode, 
                    ref string vatNumber, 
                    ref string traderName, 
                    ref string traderCompanyType, 
                    ref string traderStreet, 
                    ref string traderPostcode, 
                    ref string traderCity, 
                    string requesterCountryCode, 
                    string requesterVatNumber, 
                    out bool valid, 
                    out string traderAddress, 
                    out ViesVat.matchCode traderNameMatch, 
                    out ViesVat.matchCode traderCompanyTypeMatch, 
                    out ViesVat.matchCode traderStreetMatch, 
                    out ViesVat.matchCode traderPostcodeMatch, 
                    out ViesVat.matchCode traderCityMatch, 
                    out string requestIdentifier)
        {
            ViesVat.checkVatApproxRequest inValue = new ViesVat.checkVatApproxRequest();
            inValue.countryCode = countryCode;
            inValue.vatNumber = vatNumber;
            inValue.traderName = traderName;
            inValue.traderCompanyType = traderCompanyType;
            inValue.traderStreet = traderStreet;
            inValue.traderPostcode = traderPostcode;
            inValue.traderCity = traderCity;
            inValue.requesterCountryCode = requesterCountryCode;
            inValue.requesterVatNumber = requesterVatNumber;
            ViesVat.checkVatApproxResponse retVal = ((ViesVat.checkVatPortType)(this)).checkVatApprox(inValue);
            countryCode = retVal.countryCode;
            vatNumber = retVal.vatNumber;
            valid = retVal.valid;
            traderName = retVal.traderName;
            traderCompanyType = retVal.traderCompanyType;
            traderAddress = retVal.traderAddress;
            traderStreet = retVal.traderStreet;
            traderPostcode = retVal.traderPostcode;
            traderCity = retVal.traderCity;
            traderNameMatch = retVal.traderNameMatch;
            traderCompanyTypeMatch = retVal.traderCompanyTypeMatch;
            traderStreetMatch = retVal.traderStreetMatch;
            traderPostcodeMatch = retVal.traderPostcodeMatch;
            traderCityMatch = retVal.traderCityMatch;
            requestIdentifier = retVal.requestIdentifier;
            return retVal.requestDate;
        }
        
        public System.Threading.Tasks.Task<ViesVat.checkVatApproxResponse> checkVatApproxAsync(ViesVat.checkVatApproxRequest request)
        {
            return base.Channel.checkVatApproxAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.checkVatPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.checkVatPort))
            {
                return new System.ServiceModel.EndpointAddress("http://ec.europa.eu/taxation_customs/vies/services/checkVatService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return checkVatPortTypeClient.GetBindingForEndpoint(EndpointConfiguration.checkVatPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return checkVatPortTypeClient.GetEndpointAddress(EndpointConfiguration.checkVatPort);
        }
        
        public enum EndpointConfiguration
        {
            
            checkVatPort,
        }
    }
}
