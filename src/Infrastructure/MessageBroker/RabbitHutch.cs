﻿using OnlineStore.Application.Common.Interfaces;
using RabbitMQ.Client;

namespace OnlineStore.Infrastructure.MessageBroker;
public class RabbitHutch
{
    private static ConnectionFactory _factory;
    private static IConnection _connection;
    private static IModel _channel;

    public static IBus CreateBus(string hostName)
    {
        _factory = new ConnectionFactory
        {
            HostName = hostName,
            DispatchConsumersAsync = true
        };
        _connection = _factory.CreateConnection();
        _channel = _connection.CreateModel();
        return new RabbitBus(_channel);
    }

    public static IBus CreateBus(
    string hostName,
    ushort hostPort,
    string virtualHost,
    string username,
    string password)
    {
        _factory = new ConnectionFactory
        {
            HostName = hostName,
            Port = hostPort,
            VirtualHost = virtualHost,
            UserName = username,
            Password = password,
            DispatchConsumersAsync = true
        };

        _connection = _factory.CreateConnection();
        _channel = _connection.CreateModel();
        return new RabbitBus(_channel);
    }
}
