using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SL_WCF
{
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; } //validando, manejar el flujo de mi codigo, me dices si salio bien o no mi metodo
        [DataMember]
        public string ErrorMessage { get; set; } //almanecenar el mensaje de error
        [DataMember]
        public object Object { get; set; } //Solo un objeto
        [DataMember]
        public List<object> Objects { get; set; } //Lista de objetos 
        [DataMember]
        public Exception Ex { get; set; } //almacenar la excepción completa
    }
}