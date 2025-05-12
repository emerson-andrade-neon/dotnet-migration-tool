using DotNetMigrationTooll.Actions;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetMigrationTooll.Workflows;
using DotNetMigrationTooll.Runners;

namespace DotNetMigrationTooll.Serialization;


public class ActionConverter : JsonConverter<IAction>
{
    public override IAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var doc = JsonDocument.ParseValue(ref reader))
        {
            var element = doc.RootElement;
            var typeName = element.GetProperty("Type").GetString();

            // Usar reflexão para obter o tipo da implementação
            var actionType = Type.GetType(typeName);
            if (actionType == null)
            {
                throw new NotSupportedException($"Tipo de ação '{typeName}' não é suportado.");
            }

            // Criar uma instância da ação usando reflexão
            var action = (IAction)Activator.CreateInstance(actionType);
            return action; // Retorna a instância criada
        }
    }

    public override void Write(Utf8JsonWriter writer, IAction value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Type", value.GetType().FullName);
        // Adicione aqui a serialização dos outros campos necessários da IAction
        writer.WriteEndObject();
    }
}

public static class SerializerExtensions
{
    public static void Serializer(this Runner batchExecutor)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new ActionConverter());

        var toSerializar = batchExecutor.Workflows.Select(e => new SerializerTemp()
        {
            Executions = e.Activities.ToArray(),
            Context = e.Context
        });
        var json = System.Text.Json.JsonSerializer.Serialize(toSerializar, options);
        File.WriteAllText(AppEnvironment.SavedPath, json);
    }

    public static Runner CreateFromJson(IWorkflowObserver observer)
    {
        if (!File.Exists(AppEnvironment.SavedPath))
        {
            return new Runner(AppEnvironment.GetStandardActions(), observer);
        }

        var json = File.ReadAllText(AppEnvironment.SavedPath);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new ActionConverter());
        var temps = System.Text.Json.JsonSerializer.Deserialize<SerializerTemp[]>(json, options) ?? [];
        var executors = new List<Workflow>();

        foreach (var temp in temps)
        {
            executors.Add(new Workflow(temp.Context, temp.Executions, observer));
        }

        return new Runner(AppEnvironment.GetStandardActions(), observer)
        {
            Workflows = executors
        };
    }

    internal class SerializerTemp
    {
        public Activity[] Executions { get; set; }

        public Context Context { get; set; }
    }
}

