using CAPNet.Models;
using CAPNet.Validator.Alert;

namespace CAPNet
{
    /// <summary>
    /// Parameter must have value and valueName not null
    /// </summary>
    public class ParameterValidator : GeneralNamedValueValidator<Parameter>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        public ParameterValidator(Parameter parameter) : base(parameter) { }
    }
}
