using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordRPC.Helper
{
    internal static class SerializerConstants
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            IgnoreNullValues = true,
            WriteIndented = false,
            PropertyNameCaseInsensitive = true,
            Converters = { new OptOutJsonConverterFactory(new JsonStringEnumConverter(), typeof(Party.PrivacySetting) ) }
        };

        private class OptOutJsonConverterFactory : JsonConverterFactoryDecorator
        {
            readonly HashSet<Type> _optOutTypes;

            public OptOutJsonConverterFactory(JsonConverterFactory innerFactory, params Type[] optOutTypes) : base(innerFactory)
            {
                _optOutTypes = new HashSet<Type>();
                foreach (var type in optOutTypes)
                    _optOutTypes.Add(type);
            }

            public override bool CanConvert(Type typeToConvert) => base.CanConvert(typeToConvert) && !_optOutTypes.Contains(typeToConvert);
        }

        private class JsonConverterFactoryDecorator : JsonConverterFactory
        {
            readonly JsonConverterFactory _innerFactory;

            protected JsonConverterFactoryDecorator(JsonConverterFactory innerFactory)
            {
                this._innerFactory = innerFactory ?? throw new ArgumentNullException(nameof(innerFactory));
            }

            public override bool CanConvert(Type typeToConvert) => _innerFactory.CanConvert(typeToConvert);

            public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) => _innerFactory.CreateConverter(typeToConvert, options);
        }
    }
}
