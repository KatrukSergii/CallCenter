using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Metadata;
using NHibernate.Type;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public static class WcfResolver
    {
        public static List<T> ResolveList<T>(List<T> entityList, ISession session) where T : class
        {
            // create a resolved entities list for peace and sharing
            List<object> resolvedEntities = new List<object>();
            // loop over elements
            for (int entityListIndex = 0; entityListIndex < entityList.Count; entityListIndex++)
                entityList[entityListIndex] = Resolve<T>(entityList[entityListIndex], session, resolvedEntities);

            // done
            return entityList;
        }

        public static T[] ResolveArray<T>(T[] entityArray, ISession session) where T : class
        {
            // create a resolved entities list for peace and sharing
            List<object> resolvedEntities = new List<object>();
            // loop over elements
            for (int entityArrayIndex = 0; entityArrayIndex < entityArray.Length; entityArrayIndex++)
                entityArray[entityArrayIndex] = Resolve<T>(entityArray[entityArrayIndex], session, resolvedEntities);

            // done
            return entityArray;
        }

        public static T Resolve<T>(T entity, ISession session) where T : class
        {
            // forward to resolver
            return Resolve<T>(entity, session, new List<object>());
        }

        private static T Resolve<T>(T entity, ISession session, List<object> resolvedEntities) where T : class

        {
            // CHECKS //

            // if the entity is null, just skip it
            if (entity == null)
                return default(T);
            // if we have already resolved it, return that
            if (resolvedEntities.Contains(entity))
                return entity;

            // RESOLVE ENTITY //

            T resolvedEntity = default(T);
            // now lets go ahead and make sure everything is unproxied
            try
            {
                resolvedEntity = (T) session.GetSessionImplementation().PersistenceContext.Unproxy(entity);
            }
            catch (Exception ex)
            {
                return default(T);
            }
            // add entity to the list of resolved entities
            resolvedEntities.Add(resolvedEntity);

            // GET TYPE INFO //

            IClassMetadata entityMetadata = null;
            // get the entity type
            Type entityType = entity.GetType();
            // get the entity meta data from the type
            try
            {
                entityMetadata = session.SessionFactory.GetClassMetadata(entityType);
            }
            catch (Exception ex)
            {
                return default(T);
            }

            // PERFORM PROPERTY DIVE //

            String propertyName;
            Object propertyValue;
            Type propertyListType;
            IType entityPropertyType = null;
            Type propertyListInternalType;
            // get properties for this object
            PropertyInfo[] propertyInfos = entityType.GetProperties();
            // loop over source properties & compare
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                // get property name
                propertyName = propertyInfo.Name;
                // get property type
                try
                {
                    entityPropertyType = entityMetadata.GetPropertyType(propertyName);
                }
                catch (Exception ex)
                {
                    continue;
                }
                // get property value
                propertyValue = propertyInfo.GetValue(entity, null);
                // these are not the good kind of bags :P
                if (entityPropertyType.IsCollectionType)
                {
                    // first get the property list's internal type
                    propertyListInternalType = propertyInfo.PropertyType.GetGenericArguments()[0];
                    // create new array type based on the internal type
                    propertyListType = typeof (List<>).MakeGenericType(propertyListInternalType);
                    // create a new property list of the internal type
                    IList propertyList = (IList) Activator.CreateInstance(propertyListType);
                    // set the property list in the resolved object
                    propertyInfo.SetValue(resolvedEntity, propertyList, null);
                    // get the enumerator for this property value
                    IEnumerator enumerator = ((IEnumerable) propertyValue).GetEnumerator();
                    // loop over items to also perform resolution
                    while (enumerator.MoveNext())
                        propertyList.Add(Resolve(enumerator.Current, session, resolvedEntities));
                }
                // destroy hibernate proxies
                else if (entityPropertyType.IsEntityType)
                {
                    // set the property of the resolved entity to the child beneath us
                    propertyInfo.SetValue(resolvedEntity, Resolve(propertyValue, session, resolvedEntities), null);
                }
            }

            // return the resolved entity :)
            return resolvedEntity;
        }
    }
}