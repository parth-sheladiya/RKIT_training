﻿using System.Reflection;

namespace FinalDemo.Extention
{
    /// <summary>
    /// dto to poco conversion
    /// </summary>
    public static class ConvertExtention
    {
        
        /// <summary>
        /// Converts the DTO model to POCO Model.
        /// </summary>
        /// <typeparam name="POCO">POCO</typeparam>
        /// <param name="dto">DTO </param>
        /// <returns>Poco model.</returns>
        public static POCO Convert<POCO>(this object dto)
        {
            Type? pocoType = typeof(POCO) ?? throw new Exception();
            POCO? pocoInstance = (POCO)Activator.CreateInstance(type: pocoType);

            // Get properties
            PropertyInfo[] dtoProperties = dto.GetType().GetProperties();
            PropertyInfo[] pocoProperties = pocoType.GetProperties();

            foreach (PropertyInfo dtoProperty in dtoProperties)
            {
                PropertyInfo? pocoProperty = Array.Find(array: pocoProperties, p => p.Name == dtoProperty.Name);

                if (pocoProperty != null && dtoProperty.PropertyType == pocoProperty.PropertyType)
                {
                    object? value = dtoProperty.GetValue(dto);
                    pocoProperty.SetValue(pocoInstance, value);
                }
            }

            return pocoInstance != null ? pocoInstance : throw new Exception();
        }
       
    }
}
