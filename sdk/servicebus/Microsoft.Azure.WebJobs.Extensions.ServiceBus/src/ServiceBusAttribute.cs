﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Attribute used to bind a parameter to Azure ServiceBus Queues and Topics.
    /// </summary>
    ///// <remarks>
    ///// The method parameter type can be one of the following:
    ///// <list type="bullet">
    ///// <item><description>BrokeredMessage (out parameter)</description></item>
    ///// <item><description><see cref="string"/> (out parameter)</description></item>
    ///// <item><description><see cref="byte"/> (out parameter)</description></item>
    ///// <item><description>A user-defined type (out parameter, serialized as JSON)</description></item>
    ///// <item><description>
    ///// <see cref="ICollection{T}"/> of these types (to enqueue multiple messages via <see cref="ICollection{T}.Add"/>
    ///// </description></item>
    ///// </list>
    ///// </remarks>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [DebuggerDisplay("{QueueOrTopicName,nq}")]
    [ConnectionProvider(typeof(ServiceBusAccountAttribute))]
    [Binding]
    public sealed class ServiceBusAttribute : Attribute, IConnectionProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusAttribute"/> class.
        /// </summary>
        /// <param name="queueOrTopicName">The name of the queue or topic to bind to.</param>
        /// <param name="serviceBusEntityType">The type of the entity to bind to.</param>
        public ServiceBusAttribute(string queueOrTopicName, ServiceBusEntityType serviceBusEntityType = ServiceBusEntityType.Queue)
        {
            QueueOrTopicName = queueOrTopicName;
            ServiceBusEntityType = serviceBusEntityType;
        }

        /// <summary>
        /// Gets the name of the queue or topic to bind to.
        /// </summary>
        public string QueueOrTopicName { get; private set; }

        /// <summary>
        /// Gets or sets the app setting name that contains the Service Bus connection string.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Value indicating the type of the entity to bind to.
        /// </summary>
        public ServiceBusEntityType ServiceBusEntityType { get; set; }
    }
}
