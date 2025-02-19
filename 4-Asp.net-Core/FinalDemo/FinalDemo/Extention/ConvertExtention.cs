using System.Reflection;

namespace FinalDemo.Extention
{
    /// <summary>
    /// dto to poco conversion
    /// </summary>
    public static class ConvertExtention
    {
        
        /// <summary>
        /// Converts the DTO model to POCO Model using extension method 
        /// </summary>
        /// <typeparam name="POCO">POCO</typeparam>
        /// <param name="dto">DTO </param>
        /// <returns>Poco model.</returns>
        public static POCO Convert<POCO>(this object dto)
        {
            Type? pocoType = typeof(POCO) ?? throw new Exception();
            // it is static method it is create all type of dynamic obj
            POCO? pocoInstance = (POCO)Activator.CreateInstance(type: pocoType);

            // fetch properties for dto
            PropertyInfo[] dtoProperties = dto.GetType().GetProperties();
            // fetch property for poco
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
