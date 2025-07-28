using AspectInjector.Broker;

namespace EFCoreLab.CrossCutting.Observability.Tracing;

[Injection(typeof(TracingMethodAspect))]
public class TracingMethodAttribute : Attribute
{
}