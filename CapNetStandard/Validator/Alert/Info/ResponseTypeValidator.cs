using CAPNet.Models;
using System;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// The code denoting the type of action recommended for the target audience must have certain code values !
    /// </summary>
    public class ResponseTypeValidator : Validator<ResponseType>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="responseType"></param>
        public ResponseTypeValidator(ResponseType responseType)
            : base(responseType) { }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Enum.IsDefined(typeof(ResponseType), Entity);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new ResponseTypeError();
            }
        }
    }
}
