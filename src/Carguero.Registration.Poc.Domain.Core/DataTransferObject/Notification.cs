// <copyright file="Notification.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

namespace Carguero.Registration.Poc.Domain.Core.DataTransferObject
{
    public struct Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
