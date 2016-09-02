using System.IO.Pipes;
using Raven.Client.Listeners;
using Raven.Json.Linq;

namespace RavenShowOff
{
    public class PersonToV2Listener : IDocumentConversionListener
    {
        public void BeforeConversionToDocument(string key, object entity, RavenJObject metadata)
        {
            
        }

        public void AfterConversionToDocument(string key, object entity, RavenJObject document, RavenJObject metadata)
        {
            if (entity is Person == false)
                return;

            document.Remove(propertyName);
        }

        public void BeforeConversionToEntity(string key, RavenJObject document, RavenJObject metadata)
        {

        }
        const string propertyName = "Name";

        public void AfterConversionToEntity(string key, RavenJObject document, RavenJObject metadata, object entity)
        {
            var person = entity as Person;
            var entityIsPerson = person != null;
            if (!entityIsPerson) return;
            var documentExistedBeforeV2 = document.ContainsKey(propertyName);
            if (!documentExistedBeforeV2) return;

            var splitName = document.Value<string>(propertyName).Split(' ');
            person.FirstName = splitName[0];
            person.MiddleInitial = splitName[1];
            person.LastName = splitName[2];
        }
    }
}