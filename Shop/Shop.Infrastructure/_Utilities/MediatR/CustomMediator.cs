﻿using MediatR;

namespace Shop.Infrastructure._Utilities.MediatR;

public class CustomMediator : Mediator
{
    private readonly Func<IEnumerable<Func<INotification, CancellationToken, Task>>, INotification, CancellationToken, Task> _publish;


    public CustomMediator(IServiceProvider serviceProvider, Func<IEnumerable<Func<INotification, CancellationToken, Task>>, INotification, CancellationToken, Task> publish) : base(serviceProvider)
    {
        _publish = publish;
    }

    public CustomMediator(IServiceProvider serviceProvider, INotificationPublisher publisher, Func<IEnumerable<Func<INotification, CancellationToken, Task>>, INotification, CancellationToken, Task> publish) : base(serviceProvider, publisher)
    {
        _publish = publish;
    }

    protected override Task PublishCore(IEnumerable<NotificationHandlerExecutor> handlerExecutors, INotification notification, CancellationToken cancellationToken)
    {
        return base.PublishCore(handlerExecutors, notification, cancellationToken);
    }


}