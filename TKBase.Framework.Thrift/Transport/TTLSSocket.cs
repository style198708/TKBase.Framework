/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements. See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership. The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace TKBase.Framework.Thrift.Transport
{
    /// <summary>
    /// SSL Socket Wrapper class
    /// </summary>
    public class TTLSSocket : TStreamTransport
    {
        /// <summary>
        /// Internal TCP Client
        /// </summary>
        private TcpClient client = null;

        /// <summary>
        /// The host
        /// </summary>
        private readonly string host = null;

        /// <summary>
        /// The port
        /// </summary>
        private readonly int port = 0;

        /// <summary>
        /// The timeout for the connection
        /// </summary>
        private int timeout = 0;

        /// <summary>
        /// Internal SSL Stream for IO
        /// </summary>
        private SslStream secureStream = null;

        /// <summary>
        /// Defines wheter or not this socket is a server socket<br/>
        /// This is used for the TLS-authentication
        /// </summary>
        private readonly bool isServer = false;

        /// <summary>
        /// The certificate
        /// </summary>
        private readonly X509Certificate certificate = null;

        /// <summary>
        /// User defined certificate validator.
        /// </summary>
        private readonly RemoteCertificateValidationCallback certValidator = null;

        /// <summary>
        /// The function to determine which certificate to use.
        /// </summary>
        private readonly LocalCertificateSelectionCallback localCertificateSelectionCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="TTLSSocket"/> class.
        /// </summary>
        /// <param name="client">An already created TCP-client</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="isServer">if set to <c>true</c> [is server].</param>
        /// <param name="certValidator">User defined cert validator.</param>
        /// <param name="localCertificateSelectionCallback">The callback to select which certificate to use.</param>
        public TTLSSocket(
            TcpClient client,
            X509Certificate certificate,
            bool isServer = false,
            RemoteCertificateValidationCallback certValidator = null,
            LocalCertificateSelectionCallback localCertificateSelectionCallback = null)
        {
            this.client = client;
            this.certificate = certificate;
            this.certValidator = certValidator;
            this.localCertificateSelectionCallback = localCertificateSelectionCallback;
            this.isServer = isServer;

            if (IsOpen)
            {
                base.inputStream = client.GetStream();
                base.outputStream = client.GetStream();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TTLSSocket"/> class.
        /// </summary>
        /// <param name="host">The host, where the socket should connect to.</param>
        /// <param name="port">The port.</param>
        /// <param name="certificatePath">The certificate path.</param>
        /// <param name="certValidator">User defined cert validator.</param>
        /// <param name="localCertificateSelectionCallback">The callback to select which certificate to use.</param>
        public TTLSSocket(
            string host,
            int port,
            string certificatePath,
            RemoteCertificateValidationCallback certValidator = null,
            LocalCertificateSelectionCallback localCertificateSelectionCallback = null)
            : this(host, port, 0, X509Certificate.CreateFromCertFile(certificatePath), certValidator, localCertificateSelectionCallback)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TTLSSocket"/> class.
        /// </summary>
        /// <param name="host">The host, where the socket should connect to.</param>
        /// <param name="port">The port.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="certValidator">User defined cert validator.</param>
        /// <param name="localCertificateSelectionCallback">The callback to select which certificate to use.</param>
        public TTLSSocket(
            string host,
            int port,
            X509Certificate certificate,
            RemoteCertificateValidationCallback certValidator = null,
            LocalCertificateSelectionCallback localCertificateSelectionCallback = null)
            : this(host, port, 0, certificate, certValidator, localCertificateSelectionCallback)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TTLSSocket"/> class.
        /// </summary>
        /// <param name="host">The host, where the socket should connect to.</param>
        /// <param name="port">The port.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="certValidator">User defined cert validator.</param>
        /// <param name="localCertificateSelectionCallback">The callback to select which certificate to use.</param>
        public TTLSSocket(
            string host,
            int port,
            int timeout,
            X509Certificate certificate,
            RemoteCertificateValidationCallback certValidator = null,
            LocalCertificateSelectionCallback localCertificateSelectionCallback = null)
        {
            this.host = host;
            this.port = port;
            this.timeout = timeout;
            this.certificate = certificate;
            this.certValidator = certValidator;
            this.localCertificateSelectionCallback = localCertificateSelectionCallback;

            InitSocket();
        }

        /// <summary>
        /// Creates the TcpClient and sets the timeouts
        /// </summary>
        private void InitSocket()
        {
            this.client = new TcpClient();
            client.ReceiveTimeout = client.SendTimeout = timeout;
            client.Client.NoDelay = true;
        }

        /// <summary>
        /// Sets Send / Recv Timeout for IO
        /// </summary>
        public int Timeout
        {
            set
            {
                this.client.ReceiveTimeout = this.client.SendTimeout = this.timeout = value;
            }
        }

        /// <summary>
        /// Gets the TCP client.
        /// </summary>
        public TcpClient TcpClient
        {
            get
            {
                return client;
            }
        }

        /// <summary>
        /// Gets the host.
        /// </summary>
        public string Host
        {
            get
            {
                return host;
            }
        }

        /// <summary>
        /// Gets the port.
        /// </summary>
        public int Port
        {
            get
            {
                return port;
            }
        }

        /// <summary>
        /// Gets a value indicating whether TCP Client is Cpen
        /// </summary>
        public override bool IsOpen
        {
            get
            {
                if (this.client == null)
                {
                    return false;
                }

                return this.client.Connected;
            }
        }

        /// <summary>
        /// Validates the certificates!<br/>
        /// </summary>
        /// <param name="sender">The sender-object.</param>
        /// <param name="certificate">The used certificate.</param>
        /// <param name="chain">The certificate chain.</param>
        /// <param name="sslPolicyErrors">An enum, which lists all the errors from the .NET certificate check.</param>
        /// <returns></returns>
        private bool DefaultCertificateValidator(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslValidationErrors)
        {
            return (sslValidationErrors == SslPolicyErrors.None);
        }

        /// <summary>
        /// Connects to the host and starts the routine, which sets up the TLS
        /// </summary>
        public override void Open()
        {
            if (IsOpen)
            {
                throw new TTransportException(TTransportException.ExceptionType.AlreadyOpen, "Socket already connected");
            }

            if (String.IsNullOrEmpty(host))
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot open null host");
            }

            if (port <= 0)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot open without port");
            }

            if (client == null)
            {
                InitSocket();
            }

            client.Connect(host, port);

            setupTLS();
        }

        /// <summary>
        /// Creates a TLS-stream and lays it over the existing socket
        /// </summary>
        public void setupTLS()
        {
            RemoteCertificateValidationCallback validator = this.certValidator ?? DefaultCertificateValidator;
            
            if( this.localCertificateSelectionCallback != null)
            {
                this.secureStream = new SslStream(
                    this.client.GetStream(),
                    false,
                    validator,
                    this.localCertificateSelectionCallback
                );
            }
            else
            {
                this.secureStream = new SslStream(
                    this.client.GetStream(),
                    false,
                    validator
                );
            }
            
            try
            {
                if (isServer)
                {
                    // Server authentication
                    this.secureStream.AuthenticateAsServer(this.certificate, this.certValidator != null, SslProtocols.Tls, true);
                }
                else
                {
                    // Client authentication
                    this.secureStream.AuthenticateAsClient(host, new X509CertificateCollection { certificate }, SslProtocols.Tls, true);
                }
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }

            inputStream = this.secureStream;
            outputStream = this.secureStream;
        }

        /// <summary>
        /// Closes the SSL Socket
        /// </summary>
        public override void Close()
        {
            base.Close();
            if (this.client != null)
            {
                this.client.Close();
                this.client = null;
            }

            if (this.secureStream != null)
            {
                this.secureStream.Close();
                this.secureStream = null;
            }
        }
    }
}
