# GRPC instructions for developing server and client

GRPC uses .proto file for communication protocols. It will contain the request type reply type and the procedures which can be called by client to server
## Install nuget packages
1. Google.Protobuf(all projects using grpc): To work with the proto files
1. Grpc.Net.Client(client project): To talk to grpc servers.
1. Grpc.Tools(global): Visual Studio tooling for working with grpc files.

## Proto file description

1. **syntax:** mentions the proto schema.
    - Usage: syntax = "proto3";
1. **csharp_namespace** mentions the namespace of the class generated.
1. **package** name of the package.
1. **service** class with procedures in it.
    - Syntax:
    ```cs
    Service ServiceName
    {
        rpc ProcedureName (RequestModelName) returns (ReplyModelName);
    }
    ```

    This is equivalent to
    ```cs
    Class ServiceName
    {
        ReplyModelName ProcedureName(RequestModelName);
    }
    ```
    - ```ServiceName``` is the name of the class.
    - ```ProcedureName``` corresponds to the method name which we will call.
    - ```RequestModelName``` is the ModelName of request.
    - ```ReplyModelName``` is the ModelName of returned object.

1. **message** definition for a model(class) in C#.
    - Syntax: 
    ```cs
    message ModelName
    {
    Type propertyName = 1;
    Type anotherPropertyName = 2;
    }
    ```
    - message has a name ```ModelName```
    - In the body specify the type, name and the order in which the property will appear, for each property in the format ```TypeOfProperty NameOfProperty = OrderOfProperty```.

## GRPC Server

### Adding services
1. Create a class with the name of the endpoint ```EndpointService``` and implement the base class from proto file ```ServiceName.ServiceNameBase```
1. Create constructor and inject dependencies if any.
1. Use
```cs
public override Task<ReplyModelName> ProcedureName(RequestModelName request, ServerCallContext context)
{
    return Task.FromResult(response);
}
```
