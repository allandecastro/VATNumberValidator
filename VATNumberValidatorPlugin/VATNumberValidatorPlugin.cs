using Microsoft.Xrm.Sdk;
using System;
using System.Linq;
using ViesVat;

namespace VATNumberValidatorPlugin
{
    public class ValidateVAT : PluginBase
    {
        public ValidateVAT(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(ValidateVAT))
        {
        }

        // Entry point for custom business logic execution
        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            string input = context.InputParameters["VAT"] as string;
            localPluginContext.Trace($"input: {input}");
            input = input.Replace(" ", "").ToUpper(); // general cleaning of input

            string country = new string(input.Take(2).ToArray());
            string vat = new string(input.Skip(2).ToArray());

            localPluginContext.Trace($"country: {country}, vat: {vat}");

            var service = new checkVatPortTypeClient();
            service.checkVat(ref country, ref vat, out bool valid, out string name, out string address);

            localPluginContext.Trace($"valid: {valid}, name: {name}, address: {address}");
            context.OutputParameters["Valid"] = valid;
            context.OutputParameters["Name"] = name;
            context.OutputParameters["Address"] = address;
        }
    }
}
