using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Pensees.CargoX.Web.Host.ModelBinder
{
    public class RawStringDateTimeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                var date = DateTime.ParseExact(value.ToString(), "yyyyMMddhhmmss", CultureInfo.InvariantCulture);
            }

            return Task.CompletedTask;
        }
    }
}
