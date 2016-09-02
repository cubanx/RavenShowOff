using System;
using Raven.Client;
using Raven.Client.Document;

namespace RavenShowOff
{
    internal partial class Program
    {
        public static class DocumentStoreHolder
        {
            private static readonly Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

            public static IDocumentStore Store => store.Value;

            private static IDocumentStore CreateStore()
            {
                var store = new DocumentStore
                {
                    Url = "http://localhost:8080",
                    DefaultDatabase = "Northwind"
                }.Initialize();

                store.Listeners.RegisterListener(new PersonToV2Listener());

                return store;
            }
        }
    }
}