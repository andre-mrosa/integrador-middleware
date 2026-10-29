using System.Text.Json;
using System.Text.Json.Serialization;

namespace Integrador.Source.Http;

internal static class SourceJson
{
    // API em snake_case. Números podem vir como string e vice-versa; booleanos como "true"/"false" (ex: error).
    public static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new LenientStringConverter(), new LenientBoolConverter() }
    };
}

/// <summary>
/// Lê booleanos que vêm como string ("true"/"false") ou número (1/0). Ex: "error": "false" em todas as respostas.
/// Também serve para bool? (o System.Text.Json usa o conversor de bool nos nullable).
/// </summary>
internal sealed class LenientBoolConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType switch
    {
        JsonTokenType.True => true,
        JsonTokenType.False => false,
        JsonTokenType.String => IsTrue(reader.GetString()),
        JsonTokenType.Number => reader.TryGetInt64(out long l) && l != 0,
        _ => throw new JsonException($"Valor booleano inválido ({reader.TokenType}).")
    };

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) => writer.WriteBooleanValue(value);

    internal static bool IsTrue(string? value) => value?.Trim().ToLowerInvariant() is "true" or "1";
}

/// <summary>
/// Lê números/booleanos como string (ex: um código pode vir como 123 ou "123").
/// </summary>
internal sealed class LenientStringConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType switch
    {
        JsonTokenType.String => reader.GetString(),
        JsonTokenType.Number => reader.TryGetInt64(out long l) ? l.ToString() : reader.GetDecimal().ToString(System.Globalization.CultureInfo.InvariantCulture),
        JsonTokenType.True => "true",
        JsonTokenType.False => "false",
        JsonTokenType.Null => null,
        _ => JsonDocument.ParseValue(ref reader).RootElement.GetRawText()
    };

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (value == null) writer.WriteNullValue();
        else writer.WriteStringValue(value);
    }
}
